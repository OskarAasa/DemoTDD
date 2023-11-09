using LogErrorWebApi;
using LogErrorWebApi.Data;
using LogErrorWebApi.Models;
using Microsoft.AspNetCore.Mvc.Formatters.Xml;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Test.DemoTDD
{
    public class TestWebApi : IDisposable
    {
        private WebApplicationFactory<Program> webApi;
        private HttpClient httpClient;
        private static DbContextOptions<LogErrorWebApiContext> options = new DbContextOptionsBuilder<LogErrorWebApiContext>()
            .UseInMemoryDatabase(databaseName: "LogErrorWebApiContext-9c63f255-339a-481a-8413-b7dc4eaf3caf").Options;

        LogErrorWebApiContext logErrorWebApiContext;
        public TestWebApi()
        {
            webApi = new WebApplicationFactory<LogErrorWebApi.Program>();
            httpClient = webApi.CreateDefaultClient();
            logErrorWebApiContext = new LogErrorWebApiContext(options);
            logErrorWebApiContext.Database.EnsureCreated();
            SeedDatabase();
        }
        private void SeedDatabase()
        {
            List<ErrorReport> errors = new List<ErrorReport>()
            {
            new ErrorReport()
            {
                Headline = "Test1",
                DateTime = DateTime.Now,
                Description = "Test1",
                Recreate = "Test1",
                ExpectedResult = "Test1",
                ActualResult = "Test1",
                Frequency = 3,
                SystemInfo = "Test1"
            },
            new ErrorReport()
            {
                Headline = "Test2",
                DateTime = DateTime.Now,
                Description = "Test2",
                Recreate = "Test2",
                ExpectedResult = "Test2",
                ActualResult = "Test2",
                Frequency = 3,
                SystemInfo = "Test2"
            },
            new ErrorReport()
            {
                Headline = "Test3",
                DateTime = DateTime.Now,
                Description = "Test3",
                Recreate = "Test3",
                ExpectedResult = "Test3",
                ActualResult = "Test3",
                Frequency = 3,
                SystemInfo = "Test3"
            },
            new ErrorReport()
            {
                Headline = "Test4",
                DateTime = DateTime.Now,
                Description = "Test4",
                Recreate = "Test4",
                ExpectedResult = "Test4",
                ActualResult = "Test4",
                Frequency = 3,
                SystemInfo = "Test4"
            }
        };

            logErrorWebApiContext.ErrorReport.AddRange(errors);
            logErrorWebApiContext.SaveChanges();

        }

        [Fact]
        public void InMemoryGetError()
        {
            List<ErrorReport> allErrors;

            allErrors = logErrorWebApiContext.ErrorReport.ToList();

            Assert.Equal(4, allErrors.Count);
        }
        [Fact]
        public void InMemoryPostError()
        {
            List<ErrorReport> allErrors;
            ErrorReport errorReport;
            var report = new ErrorReport
            {
                Headline = "Test5",
                DateTime = DateTime.Now,
                Description = "Test5",
                Recreate = "Test5",
                ExpectedResult = "Test5",
                ActualResult = "Test5",
                Frequency = 3,
                SystemInfo = "Test5"
            };
            logErrorWebApiContext.ErrorReport.Add(report);
            logErrorWebApiContext.SaveChanges();
            errorReport = logErrorWebApiContext.ErrorReport.FirstOrDefault(x=>x.Headline == "Test5");
            Assert.Equal("Test5", errorReport.Headline);
           
        }
        [Fact]
        public void InMemoryDeleteError()
        {
            ErrorReport errorReport;
            List<ErrorReport> allErrors;

            errorReport = logErrorWebApiContext.ErrorReport.FirstOrDefault(x=>x.Headline == "Test4");

            logErrorWebApiContext.ErrorReport.Remove(errorReport);
            logErrorWebApiContext.SaveChanges();
            allErrors = logErrorWebApiContext.ErrorReport.ToList();

            Assert.Equal(3, allErrors.Count);
        }

        [Fact]
        public async Task GetErrorReport()
        {
            var response = await httpClient.GetAsync("https://localhost:7260/api/ErrorReports");
            string result = await response.Content.ReadAsStringAsync();

            Assert.Contains("2023-11-07", result);
        }
        [Fact]
        public async Task PostErrorReport()
        {
            var report = new ErrorReport
            {
                Headline = "Test2",
                DateTime = DateTime.Now,
                Description = "Test2",
                Recreate = "Test2",
                ExpectedResult = "Test2",
                ActualResult = "Test2",
                Frequency = 3,
                SystemInfo = "Test2"
            };
            var respone = await httpClient.PostAsJsonAsync("https://localhost:7260/api/ErrorReports", report);
            //respone.EnsureSuccessStatusCode();
            Assert.True(respone.IsSuccessStatusCode);
        }
        //[Fact]
        //public async Task DeleteErrorReport()
        //{
        //    int id = 3;
        //    var response = await httpClient.DeleteAsync($"https://localhost:7260/api/ErrorReports/{id}");
        //    Assert.True(response.IsSuccessStatusCode);
        //}

        public void Dispose()
        {
            logErrorWebApiContext.Database.EnsureDeleted();
        }
    }
}
