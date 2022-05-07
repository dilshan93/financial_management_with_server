using financial_management.DTO;
using financial_management.Global;
using financial_management.Response;
using financial_management.XMLBackup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace financial_management.Models
{
    internal class CategoryModel
    {
        CategoryBackupService categoryBackup = new CategoryBackupService();
        SyncService syncService = new SyncService();
        public CategoryDTO[] GetCategories()
        {
            CategoryDTO[] categories = null;

            if (Status.IsConnected())
            {
                try
                {
                    using (var server = new HttpClient())
                    {
                        server.BaseAddress = new Uri(Status.endpointURL);
                        var responseData = server.GetAsync("category");
                        responseData.Wait();

                        var result = responseData.Result;
                        if (result.IsSuccessStatusCode)
                        {
                            var readData = result.Content.ReadAsAsync<AllCategoryResponse>();
                            readData.Wait();

                            var response = readData.Result;
                            categories = response.ReturnResponse;
                            categoryBackup.GetAllCategories(categories);
                        }
                    }
                }
                catch (Exception ex)
                {
                     categories = categoryBackup.GetAllCategories(null);
                }
            }
            else 
            {

                categories = categoryBackup.GetAllCategories(null);
            }
            

            return categories;
        }

        // Create new category in DB
        public AllCategoryResponse CreateCategory(CategoryDTO categoryDTO)
        {
            AllCategoryResponse response = null;

            if (Status.IsConnected())
            {
                try
                {
                    using (var server = new HttpClient())
                    {
                        server.BaseAddress = new Uri(Status.endpointURL);
                        var responseData = server.PostAsJsonAsync<CategoryDTO>("category/create", categoryDTO);
                        responseData.Wait();

                        var result = responseData.Result;
                        if (result.IsSuccessStatusCode)
                        {
                            var readData = result.Content.ReadAsAsync<AllCategoryResponse>();
                            readData.Wait();

                            response = readData.Result;
                            categoryBackup.CreateCategory(categoryDTO);
                        }
                    }
                }
                catch (Exception ex)
                {
                    syncService.SaveWatingSyncState();
                    categoryDTO.Id = Status.GetCategoryId();
                    response = categoryBackup.CreateCategory(categoryDTO);
                }

            }
            else
            {
                syncService.SaveWatingSyncState();
                categoryDTO.Id = Status.GetCategoryId();
                response = categoryBackup.CreateCategory(categoryDTO);

            }
            return response;
        }

        // Load category from DB
        /*public void LoadCategory(BudgetStore.CategoryDbRow row)
        {
            CategoryDTO categoryDTO = new CategoryDTO();
            categoryDTO.Id = row.Id;
            categoryDTO.Name = row.Name;
        }*/

        // Update category row in DB
        /*public void UpdatCategory(BudgetStore.CategoryDbRow row, String name)
        {
            row.Name = name;
            row.AcceptChanges();
        }*/

        public AllCategoryResponse DeleteCategory(int id)
        {

            AllCategoryResponse response = new AllCategoryResponse();
            try
            {
                using (var server = new HttpClient())
                {
                    server.BaseAddress = new Uri(Status.endpointURL);
                    var responseData = server.DeleteAsync("category?id=" + id);
                    responseData.Wait();

                    var result = responseData.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readData = result.Content.ReadAsAsync<AllCategoryResponse>();
                        readData.Wait();

                        response = readData.Result;
                        // store.GetCategories(categories);
                    }
                }
            }
            catch (Exception ex)
            {
                response.Sucess = false;
                response.Discription = "Connection Lost! Delete action can't be proform without server connection";
            }
            return response;
        }
    }
}
