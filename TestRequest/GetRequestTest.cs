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
        }

        [Fact]
        public async Task Get_One_Success()
        {
            DateTime response = await HttpHelper.Get<DateTime>("/api/values/1");
            Assert.Equal(5, response.Day);
        }

        [Fact]
        public async Task Get_OneWithTwoParameters_Success()
        {
            string response = await HttpHelper.Get<string>($"/api/values/{1}/{2}");
            Assert.Equal($"{1}{2}", response);
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
