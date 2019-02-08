using HttpRequestHelper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace TestRequest
{
    public class GetRequestTest
    {
        public GetRequestTest()
        {
            HttpHelper.BaseApiAddress("https://testapiforhelper.azurewebsites.net/");
        }

        [Fact]
        public async Task Get_Collecton_Success()
        {
            List<string> response = await HttpHelper.Get<List<string>>("/api/values");
            Assert.Equal("value1", response[0]);
            Assert.Equal("value2", response[1]);
        }

        [Fact]
        public async Task Get_One_Success()
        {
            DateTime response = await HttpHelper.Get<DateTime>("/api/values/1");
            Assert.Equal(2000, response.Year);
            Assert.Equal(10, response.Month);
            Assert.Equal(5, response.Day);
        }

        [Fact]
        public async Task Get_OneString_Success()
        {
            int firstParam = 1;
            int secondParam = 2;
            string response = await HttpHelper.Get<string>($"/api/values/{firstParam}/{secondParam}");
            Assert.Equal($"{firstParam}{secondParam}", response);
        }

        [Fact]
        public async Task Post_Success()
        {
            var response = await HttpHelper.Post<string>("/api/values", "test");
            Assert.True(response);
        }

        [Fact]
        public async Task Put_Success()
        {
            var response = await HttpHelper.Put<string>("/api/values", "test");
            Assert.True(response);
        }

        [Fact]
        public async Task Delete_Success()
        {
            var response = await HttpHelper.Delete("/api/values/3");
            Assert.True(response);
        }
    }
}
