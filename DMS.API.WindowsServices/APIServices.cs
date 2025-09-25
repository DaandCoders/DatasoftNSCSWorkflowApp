using DC.DMS.Services.Models.Log;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.API.WindowsServices
{
    public class APIServices
    {
        HttpClient Client;

        public APIServices()
        {
            Client = new HttpClient();
            Client.Timeout = TimeSpan.FromMinutes(15);
        }

        public async Task<(bool IsSuccess, string errorMessage)> SyncDataAsync(string payLoad)
        {
            try
            {
                var url = ClientAPI.DataSyncUrl;
                Console.WriteLine($"URL: {url}");

                //var jsonPayload = JsonConvert.SerializeObject(payLoad);
                Console.WriteLine($"Payload: {payLoad}");

                var content = new StringContent(payLoad, Encoding.UTF8, "application/json");
                var response = await Client.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    return (true, await response.Content.ReadAsStringAsync());
                }
                else
                {
                    Console.WriteLine($"Error: {response.ReasonPhrase}");
                    return (false, response.ReasonPhrase ?? string.Empty);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                return (false, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, string errorMessage)> SyncDataWithStreamingAsync(Stream payloadStream)
        {
            var url = ClientAPI.DataSyncUrl;
            Console.WriteLine($"URL: {url}");

            var content = new StreamContent(payloadStream);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = await Client.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                return (true, await response.Content.ReadAsStringAsync());
            }
            else
            {
                Console.WriteLine($"Error: {response.ReasonPhrase}");
                return (false, response.ReasonPhrase ?? string.Empty);
            }
        }

        public async Task<(bool IsSuccess, string errorMessage)> SyncDataInBatchesAsync(string tableName, List<Dictionary<string, object>> rows, int batchSize)
        {
            var batches = SplitIntoBatches(rows, batchSize);
            int batchNumber = 1;

            foreach (var batch in batches)
            {
                var payload = new
                {
                    TableName = tableName,
                    Rows = batch
                };

                var jsonPayload = JsonConvert.SerializeObject(payload);

                // Send the batch
                var result = await new APIServices().SyncDataAsync(jsonPayload);

                if (!result.IsSuccess)
                {
                    Console.WriteLine($"Error in batch {batchNumber}: {result.errorMessage}");
                    return result; // Stop on the first failure
                }

                Console.WriteLine($"Batch {batchNumber} synced successfully.");
                batchNumber++;
            }

            return (true, string.Empty);
        }


        public async Task<(bool IsSuccess, string errorMessage)> SyncDataWithCompressionAsync(string payload)
        {
            var url = ClientAPI.DataSyncUrl;
            Console.WriteLine($"URL: {url}");

            var compressedPayload = Compress(payload);
            var content = new ByteArrayContent(compressedPayload);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            content.Headers.ContentEncoding.Add("gzip");

            var response = await Client.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                return (true, await response.Content.ReadAsStringAsync());
            }
            else
            {
                Console.WriteLine($"Error: {response.ReasonPhrase}");
                return (false, response.ReasonPhrase ?? string.Empty);
            }
        }

        private byte[] Compress(string data)
        {
            using (var outputStream = new MemoryStream())
            {
                using (var gzipStream = new System.IO.Compression.GZipStream(outputStream, System.IO.Compression.CompressionMode.Compress))
                using (var writer = new StreamWriter(gzipStream))
                {
                    writer.Write(data);
                }
                return outputStream.ToArray();
            }
        }
        public Stream ConvertStringToStream(string payload)
        {
            byte[] byteArray = Encoding.UTF8.GetBytes(payload);
            return new MemoryStream(byteArray);
        }
        public List<List<T>> SplitIntoBatches<T>(List<T> rows, int batchSize)
        {
            return rows
                .Select((row, index) => new { row, index })
                .GroupBy(x => x.index / batchSize)
                .Select(g => g.Select(x => x.row).ToList())
                .ToList();
        }

    }
}
