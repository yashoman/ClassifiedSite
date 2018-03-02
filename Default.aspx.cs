using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CLibrary.Controller;
using CLibrary.Common;
using System.IO;

namespace ClassifiedSiteAdmin
{
    public partial class _Default : System.Web.UI.Page
    {
        AdminMainCategoryController adminMainCategoryController = ControllerFactory.CreateAdminMainCategoryController();

        protected void Page_Load(object sender, EventArgs e)
        {
            byte[] imageData = adminMainCategoryController.GetImageDetailsByMid(4).Image;

            string base64String = Convert.ToBase64String(imageData, 0, imageData.Length);
            Image1.ImageUrl = "data:image/png;base64," + base64String;
            Image1.Visible = true;

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            // Read the file and convert it to Byte Array
            string filePath = FileUpload1.PostedFile.FileName;
            string filename = Path.GetFileName(filePath);
            string ext = Path.GetExtension(filename);
            string contenttype = String.Empty;


            //Set the contenttype based on File Extension

            switch (ext)
            {
                case ".doc":
                    contenttype = "application/vnd.ms-word";
                    break;
                case ".docx":
                    contenttype = "application/vnd.ms-word";
                    break;
                case ".xls":
                    contenttype = "application/vnd.ms-excel";
                    break;
                case ".xlsx":
                    contenttype = "application/vnd.ms-excel";
                    break;
                case ".jpg":
                    contenttype = "image/jpg";
                    break;
                case ".png":
                    contenttype = "image/png";
                    break;
                case ".gif":
                    contenttype = "image/gif";
                    break;
                case ".pdf":
                    contenttype = "application/pdf";
                    break;
            }

            if (contenttype != String.Empty)
            {
                Stream fs = FileUpload1.PostedFile.InputStream;
                BinaryReader br = new BinaryReader(fs);
                Byte[] bytes = br.ReadBytes((Int32)fs.Length);

                //insert the file into database
                int save = adminMainCategoryController.SaveMainCategories(txtName.Text, bytes, 1);

                if (save == 1)
                {
                    lblMessage.ForeColor = System.Drawing.Color.Green;

                    lblMessage.Text = "File Uploaded Successfully";
                }

            }

            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;

                lblMessage.Text = "File format not recognised." + " Upload Image/Word/PDF/Excel formats";
            }
        }
    }
}
