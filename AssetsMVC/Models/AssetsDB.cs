using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace Assets_MVC_.Models
{

    public class AssetsDBContext : DbContext
    {
        public AssetsDBContext()
            : base("name=AssetsDB")
        {

        }
        public DbSet<mas_accessory> mas_Accessory { get; set; }
        public DbSet<mas_assetLocation> mas_assetlocation { get; set; }

        public DbSet<mas_classification> mas_classification { get; set; }
        public DbSet<mas_make> mas_make { get; set; }
        public DbSet<mas_model> mas_model { get; set; }
        public DbSet<mas_owner> mas_owner { get; set; }
        public DbSet<cpuentry16> cpuentry16 { get; set; }
        public DbSet<monitorentry16> monitorentry16 { get; set; }
        public DbSet<keyboardentry16> keyboardentry16 { get; set; }
        public DbSet<mouseentry16> mouseentry16 { get; set; }

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                Database.SetInitializer(new AssetDBContextInitializer());

                base.OnModelCreating(modelBuilder);
            }

        public class AssetDBContextInitializer : DropCreateDatabaseIfModelChanges<AssetsDBContext>
        {
            protected override void Seed(AssetsDBContext dbContext)
            {
                // seed data
                base.Seed(dbContext);
     
            }
        }

        public System.Data.Entity.DbSet<AssetsMVC.Models.EntyImport> EntyImports { get; set; }
    }
    public class mas_accessory
    {
        public mas_accessory()
        {

        }
        public int id { get; set; }
        public string accessory { get; set; }
        public bool active { get; set; }
    }
    public class mas_assetLocation
    {
        public mas_assetLocation()
        {

        }
        public int id { get; set; }
        public string assetLocation { get; set; }
        public bool active { get; set; }

    }
    public class mas_classification
    {
        public mas_classification()
        {

        }
        public int id { get; set; }
        public string classification { get; set; }
        public bool active { get; set; }

    }
    public class mas_make
    {
        public mas_make()
        {

        }
        public int id { get; set; }
        public string make { get; set; }
        public int accessoryId { get; set; }

        public bool active { get; set; }
        public virtual ICollection<mas_model> Model { get; set; }

        public virtual ICollection<cpuentry16> CPU { get; set; }

    }
    public class mas_model
    {
        public mas_model()
        {

        }
        public int id { get; set; }
        public string model { get; set; }
        public int make_id { get; set; }
        public string configuration { get; set; }
        public int accessoryId { get; set; }

        public bool active { get; set; }

        
    }
    public class mas_owner
    {
        public mas_owner()
        {

        }
        public int id { get; set; }
        public string owner { get; set; }


        public bool active { get; set; }

    }
    public class cpuentry16
    {
        public cpuentry16()
        {
            warrantyupto = DateTime.Now;
            lastedit = DateTime.Now;
        }
        public int id { get; set; }

        [Required(ErrorMessage = "Asset Id is Required")]
        [Display(Name="Asset Id")]
        public string asset_id { get; set; }

        [Required(ErrorMessage = "Asset Location is Required")]
        [Display(Name="Asset Location")]
        public string assetLocation_id { get; set; }
        
        [Required(ErrorMessage = "Make is Required")] 
        [Display(Name="Make")]
        public int make_id { get; set; }

        [Required(ErrorMessage = "Model is Required")]
        [Display(Name="Model")]
        public int model_id { get; set; }

         [Required(ErrorMessage = "Product Number is Required")]
        [Display(Name="Product Number")]
        public string productnumber { get; set; }

        [Required(ErrorMessage = "Serial Number is Required")]
         [Display(Name="Serial Number")]
        public string serialnumber { get; set; }

         [Required(ErrorMessage = "Asset Owner is Required")]
        [Display(Name="Asset Owner")]
        public int assetowner { get; set; }
        [Display(Name="Configuration")]
        [DataType(DataType.MultilineText)]
        public string configuration { get; set; }

         [Required(ErrorMessage = "Asset Classification is Required")]
        [Display(Name = "AssetClassification")]
         public int classification_id { get; set; }

         [Required(ErrorMessage = "Warranty is Required")]
         [Display(Name="Warranty")]
        public bool warranty { get; set; }


       [DataType(DataType.Date)]
         [Display(Name = "Warranty Up To")]
        public DateTime? warrantyupto { get; set; }

         [Display(Name = "Remarks")]
         [DataType(DataType.MultilineText)]
        public string remarks { get; set; }
        
        public DateTime? lastedit { get; set; }

        [Display(Name = "Active/Inactive")]
         public bool active { get; set; }

        
    }

    public class monitorentry16
    {
        public monitorentry16()
        {

        }
        public int id { get; set; }

        [Display(Name = "Asset Id")]
        public string asset_id { get; set; }

        [Display(Name = "Asset Location")]
        public string assetLocation_id { get; set; }
        [Display(Name = "Make")]
        public int make_id { get; set; }
        [Display(Name = "Model")]
        public int model_id { get; set; }

        [Display(Name = "Screen Size")]
        public float screeninches{ get; set; }

        [Display(Name = "Product Number")]
        public string productnumber { get; set; }
        [Display(Name = "Serial Number")]
        public string serialnumber { get; set; }
        [Display(Name = "Asset Owner")]
        public int assetowner { get; set; }
        [Display(Name = "Configuration")]
        [DataType(DataType.MultilineText)]
        public string configuration { get; set; }

        [Display(Name = "AssetClassification")]
        public int classification_id { get; set; }

        [Display(Name = "Warranty")]
        public bool warranty { get; set; }


        [DataType(DataType.Date)]
        [Display(Name = "Warranty Up To")]
        public DateTime? warrantyupto { get; set; }

        [Display(Name = "Remarks")]
        [DataType(DataType.MultilineText)]
        public string remarks { get; set; }

        public DateTime? lastedit { get; set; }

        [Display(Name = "Active/Inactive")]
        public bool active { get; set; }

    }
    public class keyboardentry16
    {
        public keyboardentry16()
        {

        }
        public int id { get; set; }

        [Display(Name = "Asset Id")]
        public string asset_id { get; set; }

        [Display(Name = "Asset Location")]
        public string assetLocation_id { get; set; }
        [Display(Name = "Make")]
        public int make_id { get; set; }
        [Display(Name = "Model")]
        public int model_id { get; set; }

        [Display(Name = "Product Number")]
        public string productnumber { get; set; }
        [Display(Name = "Serial Number")]
        public string serialnumber { get; set; }
        [Display(Name = "Asset Owner")]
        public int assetowner { get; set; }
        
        [Display(Name = "Type")]
        public string Type{ get; set; }

        [Display(Name = "AssetClassification")]
        public int classification_id { get; set; }

        [Display(Name = "Warranty")]
        public bool warranty { get; set; }


        [DataType(DataType.Date)]
        [Display(Name = "Warranty Up To")]
        public DateTime? warrantyupto { get; set; }

        [Display(Name = "Remarks")]
        [DataType(DataType.MultilineText)]
        public string remarks { get; set; }

        public DateTime? lastedit { get; set; }

        [Display(Name = "Active/Inactive")]
        public bool active { get; set; }

    }

    public class mouseentry16
    {
        public mouseentry16()
        {

        }
        public int id { get; set; }

        [Display(Name = "Asset Id")]
        public string asset_id { get; set; }

        [Display(Name = "Asset Location")]
        public string assetLocation_id { get; set; }
        [Display(Name = "Make")]
        public int make_id { get; set; }
        [Display(Name = "Model")]
        public int model_id { get; set; }

        [Display(Name = "Product Number")]
        public string productnumber { get; set; }
        [Display(Name = "Serial Number")]
        public string serialnumber { get; set; }
        [Display(Name = "Asset Owner")]
        public int assetowner { get; set; }

        [Display(Name = "Type")]
        public string Type { get; set; }

        [Display(Name = "AssetClassification")]
        public int classification_id { get; set; }

        [Display(Name = "Warranty")]
        public bool warranty { get; set; }


        [DataType(DataType.Date)]
        [Display(Name = "Warranty Up To")]
        public DateTime? warrantyupto { get; set; }

        [Display(Name = "Remarks")]
        [DataType(DataType.MultilineText)]
        public string remarks { get; set; }

        public DateTime? lastedit { get; set; }

        [Display(Name = "Active/Inactive")]
        public bool active { get; set; }

    }


}