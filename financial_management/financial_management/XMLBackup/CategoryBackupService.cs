using financial_management.DTO;
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
                var xmlData = XElement.Load("C:/Users/scit/source/repos/Cw2_w1850877/financial_management/financial_management/Backup.xml");
                var catXml = categoryDTOs.ToList()
                                    .Select(x => new XElement("Category", new XAttribute("Id", x.Id),
                                        new XAttribute("Name", x.Name))
                                    ).ToList();
                xmlData.Descendants("Categories").Remove();
                xmlData.Add(new XElement("Categories", catXml));
                xmlData.Save("C:/Users/scit/source/repos/Cw2_w1850877/financial_management/financial_management/Backup.xml");
            }
            else
            {
                var xmlData = XElement.Load("C:/Users/scit/source/repos/Cw2_w1850877/financial_management/financial_management/Backup.xml");
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

            var xmlDoc = XElement.Load("C:/Users/scit/source/repos/Cw2_w1850877/financial_management/financial_management/Backup.xml");
            int savedCatTotal = xmlDoc.Descendants("Category")
                .Where(x => x.Attribute("Name").Value == categoryDTOs.Name)
                .Count();

            if (savedCatTotal > 0)
            {
                response.Sucess = false;
                response.Discription = "Category Already Added!";
            }
            else
            {
                xmlDoc.Add(new XElement("Categories", new XElement("Category", new XAttribute("Id", categoryDTOs.Id),
                                        new XAttribute("Name", categoryDTOs.Name))));
                xmlDoc.Save("C:/Users/scit/source/repos/Cw2_w1850877/financial_management/financial_management/Backup.xml");
                response.Sucess = true;
                response.Discription = "successfully Added New Category";
            }

            return response;
        }
    }
}
