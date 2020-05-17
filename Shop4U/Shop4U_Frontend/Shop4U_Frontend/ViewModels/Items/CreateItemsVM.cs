using Microsoft.AspNetCore.Http;
using Shop4U_Frontend.Helpers;
using Shop4U_Frontend.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Shop4U_Frontend.ViewModels
{
    public class CreateItemsVM
    {

        public CreateItemsVM()
        {
            PageTitle = "Shop4U | Create Item(s)";
            LoadCategories();
        }

        public string PageTitle { get; set; }
        public List<string> Categories { get; set; }
        public List<string> Groups { get; set; }
        public List<string> FreshFoodGroups { get; set; }
        public List<string> ProvisonGroups { get; set; }
        public List<IFormFile> ImageFiles { get; set; }

        public List<Item> models { get; set; }
        public string TextFile { get; set; }
        public string ItemCartegoryName { get; set; }
        public string ItemGroupName { get; set; }

        public void CreateItems(List<Item> itemsSaved)
        {
            models = new List<Item>();
            string path = TextFile;
            var lines = System.IO.File.ReadAllLines(path);

            for (int i = 0; i < lines.Length; i++)
            {
                var itemdata = ItemsUtil.GetItem(lines[i]);
                models.Add(new Item());
                for (int j = 0; j < itemsSaved.Count; j++)
                {
                    if(itemdata == itemsSaved[j].Name)
                    {
                        models[i].Id = itemsSaved[j].Id;
                        break;
                    }
                }
            }

            if (lines.Length == ImageFiles.Count && lines.Length > 0)
            {
                for (int i = 0; i < lines.Length; i++)
                {
                    byte[] BackgrounndPicture = ItemsUtil.ConvertToBytes(ImageFiles[i]);
                    var itemdata = ItemsUtil.GetItem(lines[i]);

                    models[i].BackgrounndPicture = BackgrounndPicture;
                    models[i].ItemCartegoryName = ItemCartegoryName;
                    models[i].ItemGroupName = ItemGroupName;
                    models[i].BackgrounndPicture = BackgrounndPicture;
                    models[i].BackgrounndPicture = BackgrounndPicture;

                    if (itemdata == null)
                    {
                        models[i].Name = "";
                    }
                    else
                    {
                        models[i].Name = itemdata;
                    }
                    
                }
            }
        }

        public void LoadCategories()
        {
            Categories = new List<string>
            {
                "Fresh Foods","Provisions","Household & Appliances"
            };
        }

        public void LoadFreshFoodGroups()
        {
            Groups = new List<string>
            {
                "Bulk Fresh Food",
                "Cereal Fresh Food",
                "Condiments Fresh Food",
                "Diary Fresh Food",
                "Dry Seafood Fresh Food",
                "Flour Fresh Food",
                "Fresh Meat Fresh Food",
                "Fresh Poultry Fresh Food",
                "Frozen Poultry Fresh Food",
                "Frozen Seafood Fresh Food",
                "Fruits Fresh Food",
                "Grains Fresh Food",
                "Oil Fresh Food",
                "Seasoning Fresh Food",
                "Tubers Fresh Food",
                "Vegetables Fresh Food",
                "Beverage & Water Provision",
                "Biscuits & Snacks Provision",
                "Bulk Provision",
                "Cereal Provision",
                "Diary Provision",
                "Flour Provision",
                "Grains Provision",
                "Groceries Provision",
                "Health and Beauty Provision"
            };
        }

        private void LoadProvisionGroups()
        {
            Groups = new List<string>
            {
                "Bulk",
                "Cereal",
                "Condiments",
                "Diary",
                "Dry Seafood",
                "Flour",
                "Fresh Meat"
            };
        }

        private void LoadHouseHoldAndAppliancesGroups()
        {
            Groups = new List<string>
            {
                "Bulk",
                "Cereal",
                "Condiments",
                "Diary",
                "Dry Seafood",
                "Flour",
                "Fresh Meat"
            };
        }
    }
}
