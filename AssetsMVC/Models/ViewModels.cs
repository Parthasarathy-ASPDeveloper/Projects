using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;
using System.ComponentModel;

namespace AssetsMVC.Models
{
    public class ViewModels
    {
    }
    public class CPUEntryDisplay
    {
        public CPUEntryDisplay()
        {


        }
        public int id { get; set; }

        [DisplayName("Asset Id")]
        [Display(Name = "Asset Id")]
        public string asset_id { get; set; }

        [DisplayName("Asset Location")]
        [Display(Name = "Asset Location")]
        public string assetLocation_id { get; set; }

        [DisplayName("Make")]
        [Display(Name = "Make")]
        public string make_id { get; set; }

        [DisplayName("Model")]
        [Display(Name = "Model")]
        public string model_id { get; set; }

        [DisplayName("Product Number")]
        [Display(Name = "Product Number")]
        public string productnumber { get; set; }

        [DisplayName("Serial Number")]
        [Display(Name = "Serial Number")]
        public string serialnumber { get; set; }

        [DisplayName("Asset Owner")]
        [Display(Name = "Asset Owner")]
        public string assetowner { get; set; }

        [DisplayName("Configuration")]
        [Display(Name = "Configuration")]
        [DataType(DataType.MultilineText)]
        public string configuration { get; set; }

        [DisplayName("Asset Classification")]
        [Display(Name = "Asset Classification")]
        public string classification_id { get; set; }

        [DisplayName("Warranty")]
        [Display(Name = "Warranty")]
        public string warranty { get; set; }

        [DisplayName("Warraty Up To")]
        [DataType(DataType.Date)]
        [Display(Name = "Warranty Up To")]
        public string warrantyupto { get; set; }

        [DisplayName("Remarks")]
        [Display(Name = "Remarks")]
        [DataType(DataType.MultilineText)]
        public string remarks { get; set; }

        [DisplayName("Active")]
        [Display(Name = "Active")]
        public string active { get; set; }


    }
    public class cpuEntyImport
    {
        [DisplayName("Insert Data")]
        [DataType(DataType.MultilineText)]
        public string getData { get; set; }
    }

    public class MonitorEntryDisplay
    {
        public MonitorEntryDisplay()
        {


        }
        public int id { get; set; }

        [DisplayName("Asset Id")]
        [Display(Name = "Asset Id")]
        public string asset_id { get; set; }

        [DisplayName("Asset Location")]
        [Display(Name = "Asset Location")]
        public string assetLocation_id { get; set; }

        [DisplayName("Make")]
        [Display(Name = "Make")]
        public string make_id { get; set; }

        [DisplayName("Model")]
        [Display(Name = "Model")]
        public string model_id { get; set; }

        [DisplayName("Product Number")]
        [Display(Name = "Product Number")]
        public string productnumber { get; set; }

        [DisplayName("Serial Number")]
        [Display(Name = "Serial Number")]
        public string serialnumber { get; set; }

        [DisplayName("Asset Owner")]
        [Display(Name = "Asset Owner")]
        public string assetowner { get; set; }

        [DisplayName("Configuration")]
        [Display(Name = "Configuration")]
        [DataType(DataType.MultilineText)]
        public string configuration { get; set; }

        [DisplayName("Asset Classification")]
        [Display(Name = "Asset Classification")]
        public string classification_id { get; set; }

        [DisplayName("Warranty")]
        [Display(Name = "Warranty")]
        public string warranty { get; set; }

        [DisplayName("Warraty Up To")]
        [DataType(DataType.Date)]
        [Display(Name = "Warranty Up To")]
        public string warrantyupto { get; set; }

        [DisplayName("Remarks")]
        [Display(Name = "Remarks")]
        [DataType(DataType.MultilineText)]
        public string remarks { get; set; }

        [DisplayName("Active")]
        [Display(Name = "Active")]
        public string active { get; set; }
    }
    public class MouseEntryDisplay
    {
        public MouseEntryDisplay()
        {


        }
        public int id { get; set; }

        [DisplayName("Asset Id")]
        [Display(Name = "Asset Id")]
        public string asset_id { get; set; }

        [DisplayName("Asset Location")]
        [Display(Name = "Asset Location")]
        public string assetLocation_id { get; set; }

        [DisplayName("Make")]
        [Display(Name = "Make")]
        public string make_id { get; set; }

        [DisplayName("Model")]
        [Display(Name = "Model")]
        public string model_id { get; set; }

        [DisplayName("Product Number")]
        [Display(Name = "Product Number")]
        public string productnumber { get; set; }

        [DisplayName("Serial Number")]
        [Display(Name = "Serial Number")]
        public string serialnumber { get; set; }

        [DisplayName("Asset Owner")]
        [Display(Name = "Asset Owner")]
        public string assetowner { get; set; }

        [DisplayName("Type")]
        [Display(Name = "Type")]
        public string Type { get; set; }

        [DisplayName("Asset Classification")]
        [Display(Name = "Asset Classification")]
        public string classification_id { get; set; }

        [DisplayName("Warranty")]
        [Display(Name = "Warranty")]
        public string warranty { get; set; }

        [DisplayName("Warraty Up To")]
        [DataType(DataType.Date)]
        [Display(Name = "Warranty Up To")]
        public string warrantyupto { get; set; }

        [DisplayName("Remarks")]
        [Display(Name = "Remarks")]
        [DataType(DataType.MultilineText)]
        public string remarks { get; set; }

        [DisplayName("Active")]
        [Display(Name = "Active")]
        public string active { get; set; }
    }

    public class KeyboardEntryDisplay
    {
        public KeyboardEntryDisplay()
        {


        }
        public int id { get; set; }

        [DisplayName("Asset Id")]
        [Display(Name = "Asset Id")]
        public string asset_id { get; set; }

        [DisplayName("Asset Location")]
        [Display(Name = "Asset Location")]
        public string assetLocation_id { get; set; }

        [DisplayName("Make")]
        [Display(Name = "Make")]
        public string make_id { get; set; }

        [DisplayName("Model")]
        [Display(Name = "Model")]
        public string model_id { get; set; }

        [DisplayName("Product Number")]
        [Display(Name = "Product Number")]
        public string productnumber { get; set; }

        [DisplayName("Serial Number")]
        [Display(Name = "Serial Number")]
        public string serialnumber { get; set; }

        [DisplayName("Asset Owner")]
        [Display(Name = "Asset Owner")]
        public string assetowner { get; set; }

        [DisplayName("Type")]
        [Display(Name = "Type")]
        public string Type { get; set; }

        [DisplayName("Asset Classification")]
        [Display(Name = "Asset Classification")]
        public string classification_id { get; set; }

        [DisplayName("Warranty")]
        [Display(Name = "Warranty")]
        public string warranty { get; set; }

        [DisplayName("Warraty Up To")]
        [DataType(DataType.Date)]
        [Display(Name = "Warranty Up To")]
        public string warrantyupto { get; set; }

        [DisplayName("Remarks")]
        [Display(Name = "Remarks")]
        [DataType(DataType.MultilineText)]
        public string remarks { get; set; }

        [DisplayName("Active")]
        [Display(Name = "Active")]
        public string active { get; set; }
    }

    public class EntyImport
    {
        public int id { get; set; }
        [DisplayName("Insert Data")]
        [DataType(DataType.MultilineText)]
        public string getData { get; set; }
    }

    public class AccessoriesDisplay
    {
        public int id { get; set; }
        //Details
        public string name { get; set; }
        public string asset_id { get; set; }
        public string make { get; set; }
        public string model { get; set; }
        public string owner { get; set; }
        public string configuration { get; set; }
        public string classification { get; set; }
        public string alink { get; set; }

    }
    public class HomePage_Var
    {
        public int cpuCount { get; set; }
        public int monitorCount { get; set; }
        public int mouseCount { get; set; }
        public int keyboardCount { get; set; }
        public int totalentries { get; set; }
        public string accessory { get; set; }
    }
    public class Charts
    {
        public int totalentries { get; set; }
        public string accessory { get; set; }

    }
    public class Summary
    {
        public string label { get; set; }
        public int Y { get; set; }
    }

}