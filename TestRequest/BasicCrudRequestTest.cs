using HttpRequestHelper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace TestRequest
{
    public class BasicCrudRequestTest
    {
        public BasicCrudRequestTest()
        {
            HttpHelper.BaseApiAddress("https://testapiforhelper.azurewebsites.net/");
        }

        /// <summary>
        ///  Check if Get return expected values from API
        /// </summary>
        [Fact]
        public async Task Get_Collecton_Success()
        {
            List<string> response = await HttpHelper.Get<List<string>>("/api/values");
            Assert.Equal("value1", response[0]);
        }

        /// <summary>
        ///  Check if Get return expected values from API
        /// </summary>
        [Fact]
        public async Task Get_One_Success()
        {
            DateTime response = await HttpHelper.Get<DateTime>("/api/values/1");
            Assert.Equal(5, response.Day);
        }

        /// <summary>
        ///  Check if Get return expected values from API
        /// </summary>
        [Fact]
        public async Task Get_OneWithTwoParameters_Success()
        {
            string response = await HttpHelper.Get<string>($"/api/values/{1}/{2}");
            Assert.Equal($"{1}{2}", response);
        }

        /// <summary>
        ///  Test if post method does not throw exeption.
        ///  Exception HttpRequestException is thrown if response is not success.
        /// </summary>
        [Fact]
        public async Task Post_Success()
        {
            await HttpHelper.Post<string>("/api/values", "test");
        }

        /// <summary>
        ///  Test if put method does not throw exeption.
        ///  Exception HttpRequestException is thrown if response is not success.
        /// </summary>
        [Fact]
        public async Task Put_Success()
        {
            await HttpHelper.Put<string>("/api/values", "test");
        }

        /// <summary>
        ///  Test if delete method does not throw exeption.
        ///  Exception HttpRequestException is thrown if response is not success.
        /// </summary>
        [Fact]
        public async Task Delete_Success()
        {
            await HttpHelper.Delete("/api/values/3");
        }
    }
}
