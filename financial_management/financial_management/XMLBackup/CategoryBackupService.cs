using financial_management.DTO;
using financial_management.Global;
using financial_management.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace financial_management.XMLBackup
{
    internal class CategoryBackupService
    {

        public CategoryDTO[] GetAllCategories(CategoryDTO[] categoryDTOs)
        {
            if (categoryDTOs != null)
            {
                /*var xmlData = XElement.Load("Backup.xml");*/
                var xmlData = Status.LoadPath;
                var catXml = categoryDTOs.ToList()
                                    .Select(x => new XElement("Category", new XAttribute("Id", x.Id),
                                        new XAttribute("Name", x.Name))
                                    ).ToList();
                xmlData.Descendants("Categories").Remove();
                xmlData.Add(new XElement("Categories", catXml));
                xmlData.Save(Status.SavePath);
            }
            else
            {
                var xmlData = Status.LoadPath;
                categoryDTOs = xmlData.Descendants("Category")
                    .Select(x => new CategoryDTO
                    {
                        Id = int.Parse(x.Attribute("Id").Value.ToString()),
                        Name = x.Attribute("Name").Value
                    }).ToArray();
            }

            return categoryDTOs;
        }

        public AllCategoryResponse CreateCategory(CategoryDTO categoryDTOs)
        {
            AllCategoryResponse response = new AllCategoryResponse();

            var xmlData = Status.LoadPath;
            int savedCatTotal = xmlData.Descendants("Category")
                .Where(x => x.Attribute("Name").Value == categoryDTOs.Name)
                .Count();

            if (savedCatTotal > 0)
            {
                response.Sucess = false;
                response.Discription = "Category Already Added!";
            }
            else
            {
                xmlData.Add(new XElement("Categories", new XElement("Category", new XAttribute("Id", categoryDTOs.Id),
                                        new XAttribute("Name", categoryDTOs.Name))));
                xmlData.Save(Status.SavePath);
                response.Sucess = true;
                response.Discription = "successfully Added New Category";
            }

            return response;
        }
    }
}
