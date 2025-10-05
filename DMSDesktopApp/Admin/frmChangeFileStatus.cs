using DC.DMS.Services.Enum;
using DC.DMS.Services.Models;
using DC.DMS.Services.WorkflowModels;
using DC.DMS.Services.WorkflowModels.Directories;
using DMS.Context.Data;
using DMS.ContextHelper.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.IO;
using System.Linq.Expressions;
using System.Runtime.ExceptionServices;

namespace DMS.DesktopApp.Admin
{

    public partial class frmChangeFileStatus : Form
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContext;
        public frmChangeFileStatus(IDbContextFactory<ApplicationDbContext> dbContext)
        {
            InitializeComponent();
            _dbContext = dbContext;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private async void btnChangeStatus_Click(object sender, EventArgs e)
        {
            await using var db = await _dbContext.CreateDbContextAsync();

            try
            {
                var fileDirectory = await db.FileDirectories
                    .FirstOrDefaultAsync(x => x.Name == txtFileName.Text);

                if (fileDirectory == null)
                {
                    MessageBox.Show("Please enter valid details first.", "Invalid Details", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }

                if (cobStatus.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select status from status drop down field.", "Empty Field", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }

                var fileDirectoryID = fileDirectory.ID;

                var subDirId = await db.SubDirectories
                    .Where(x => x.FileDirectoryID == fileDirectoryID && x.Name == cobFileType.Text)
                    .Select(x => x.ID)
                    .FirstOrDefaultAsync();

                if (subDirId == 0)
                {
                    MessageBox.Show("No sub-directory found for the given file and type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                switch (cobStatus.SelectedIndex)
                {
                    // Open for scanning
                    case 0:
                        try
                        {
                            // Delete images for this sub-directory
                            var imgList = await db.ImageFileDetails
                                .Where(x => x.SubDirectoryID == subDirId)
                                .ToListAsync();

                            if (imgList.Count > 0)
                            {
                                db.ImageFileDetails.RemoveRange(imgList);
                                await db.SaveChangesAsync();

                                // delete physical files after DB rows removed
                                foreach (var img in imgList)
                                {
                                    if (!string.IsNullOrWhiteSpace(img.Path) && File.Exists(img.Path))
                                    {
                                        try { File.Delete(img.Path); } catch { /* ignore IO issues per original behavior */ }
                                    }
                                }
                            }

                            // Delete SubDirectory

                            var subDir = await db.SubDirectories
                                .FirstOrDefaultAsync(x => x.FileDirectoryID == fileDirectoryID && x.ID == subDirId);

                            if (subDir != null)
                            {
                                db.SubDirectories.Remove(subDir);
                                await db.SaveChangesAsync();
                            }
                            else
                            {
                                MessageBox.Show("No file found for opening in scan", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            }


                            // Delete FileDirectory
                            var scanFileDirectory = await db.FileDirectories
                                .FirstOrDefaultAsync(x => x.ID == fileDirectoryID);

                            // Update Status File Details
                            var fileDetails = await db.FileDetails.Where(x => x.ID == scanFileDirectory.FileDetailID).FirstOrDefaultAsync();
                            if (fileDetails != null)
                            {
                                fileDetails.Status = WorkflowEnums.Status.FileReceive;
                                await db.SaveChangesAsync();
                            }

                            // Update DCSDirectory
                            var scanDirectory = await db.Directories
                                .FirstOrDefaultAsync(x => x.ID == fileDirectoryID);

                            if (scanDirectory != null)
                            {
                                scanDirectory.Status = WorkflowEnums.Status.FileReceive;
                                await db.SaveChangesAsync();
                            }

                            if (scanFileDirectory != null)
                            {
                                db.FileDirectories.Remove(scanFileDirectory);
                                await db.SaveChangesAsync();
                                MessageBox.Show("File status changed successfully and file opened for scan!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            }
                            else
                            {
                                MessageBox.Show("No file found for opening in Scan", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                return;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            return;
                        }
                        break;

                    // Open for QC
                    case 1:
                        try
                        {
                            // Update all image file details to Scanned
                            var imgDetails = await db.ImageFileDetails
                                .Where(x => x.SubDirectoryID == subDirId)
                                .ToListAsync();

                            if (imgDetails.Count > 0)
                            {
                                foreach (var item in imgDetails)
                                {
                                    item.Status = WorkflowEnums.Status.Scanned;
                                    item.QCCreateBy = null;
                                    item.QCUpdateBy = null;
                                    item.QCCreateDateTime = null;
                                    item.QCUpdateDateTime = null;
                                }
                                await db.SaveChangesAsync();
                            }

                            // Update SubDirectory
                            var subDir = await db.SubDirectories
                                .FirstOrDefaultAsync(x => x.FileDirectoryID == fileDirectoryID && x.ID == subDirId);

                            if (subDir != null)
                            {
                                subDir.Status = WorkflowEnums.Status.Scanned;
                                subDir.QCCreateBy = null;
                                subDir.QCUpdateBy = null;
                                subDir.CreatedDateTime = null;
                                subDir.QCUpdateDateTime = null;
                                await db.SaveChangesAsync();
                            }
                            else
                            {
                                MessageBox.Show("No File Found for Opening in QC", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            }

                            // Update FileDirectory
                            var fd = await db.FileDirectories
                                .FirstOrDefaultAsync(x => x.ID == fileDirectoryID);

                            if (fd != null)
                            {
                                fd.Status = WorkflowEnums.Status.Scanned;
                                fd.QCCreateBy = null;
                                fd.QCUpdateBy = null;
                                fd.CreatedDateTime = null;
                                fd.QCUpdateDateTime = null;
                                await db.SaveChangesAsync();
                                MessageBox.Show("File Status Changed Sucessfully and File Opened For QC!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            }
                            else
                            {
                                MessageBox.Show("No File Found for Opening in QC", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            return;
                        }
                        break;

                    // Open for dispatch
                    case 3:
                        {
                            var dispatchData = await db.DispatchedData
                                .FirstOrDefaultAsync(x => x.SubDirectoryID == subDirId);

                            var pdfFile = dispatchData?.FilePath;
                            if (!string.IsNullOrWhiteSpace(pdfFile))
                            {
                                try
                                {
                                    if (File.Exists(pdfFile)) File.Delete(pdfFile);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                    return;
                                }
                            }

                            if (dispatchData != null)
                            {
                                db.DispatchedData.Remove(dispatchData);
                                try
                                {
                                    await db.SaveChangesAsync();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                    return;
                                }
                            }

                            var fd = await db.FileDirectories
                                .FirstOrDefaultAsync(x => x.ID == fileDirectoryID);

                            if (fd != null)
                            {
                                fd.Status = WorkflowEnums.Status.QCDone;
                                fd.QCCreateBy = null;
                                fd.QCUpdateBy = null;
                                fd.CreatedDateTime = null;
                                fd.QCUpdateDateTime = null;
                                try
                                {
                                    await db.SaveChangesAsync();
                                    MessageBox.Show("File Status Changed Sucessfully and File Opened For QC!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show("No File Found for Opening in QC", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            }

                            var directory = await db.Directories
                                .FirstOrDefaultAsync(x => x.ID == fileDirectoryID);

                            if (directory != null)
                            {
                                directory.Status = WorkflowEnums.Status.QCDone;
                                try
                                {
                                    await db.SaveChangesAsync();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                    return;
                                }
                            }
                            break;
                        }

                    default:
                        break;
                }

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
        }

        private void frmChangeFileStatus_Load(object sender, EventArgs e)
        {

        }
    }
}