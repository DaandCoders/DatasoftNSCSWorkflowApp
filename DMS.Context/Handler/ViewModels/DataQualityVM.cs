using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.ContextHelper.ViewModels
{
    public class DataQualityVM
    {
    }
    public class DuplicateBarcodeVM
    {
        public string Barcode { get; set; }
        public int Count { get; set; }
    }
    public class CaseNoYearTypeVM
    {
        public string CaseNo { get; set; }
        public int CaseYear { get; set; }
        public string CaseType { get; set; }
        public int CaseTypeID { get; set; }
        public int Count { get; set; }
    }
    public class CaseNoYearTypeSectionVM
    {
        public string CaseNo { get; set; }
        public int CaseYear { get; set; }
        public string CaseType { get; set; }
        public string Section { get; set; }
        public int CaseTypeID { get; set; }
        public int Count { get; set; }
    }
    public class CaseNoYearTypeSectionActVM
    {
        public string CaseNo { get; set; }
        public int CaseYear { get; set; }
        public string CaseType { get; set; }
        public string Section { get; set; }
        public string Act { get; set; }
        public int CaseTypeID { get; set; }
        public int Count { get; set; }
    }
}
