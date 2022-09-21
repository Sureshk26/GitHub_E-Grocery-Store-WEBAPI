using AutoFixture;
using E_GroceryStoreWebApi.Controllers;
using E_GroceryStoreWebApi.Core.Interface;
using E_GroceryStoreWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace UnitTest
{
    [TestClass]
    public class CategoryControllerTest
    {
        private Mock<ICategory> _categoryRepoMock;
        private Fixture _fixture;
        private CategoryController _controller;
        public CategoryControllerTest()
        {
            _fixture = new Fixture();
            _categoryRepoMock = new Mock<ICategory>();
        }
        [TestMethod]
        public async Task GetCategoryReturnOk()
        {
            var categoryList = _fixture.CreateMany<CategoryModel>(3).ToList();
            _categoryRepoMock.Setup(repo => repo.Get()).Returns(categoryList);
            _controller = new CategoryController(_categoryRepoMock.Object);
            var result = await _controller.Get();
            var obj = result as ObjectResult;
            Assert.AreEqual(200, obj.StatusCode);
        }
        [TestMethod]
        public async Task GetCategoryThrowException()
        {
            _categoryRepoMock.Setup(repo => repo.Get()).Throws(new System.Exception());
            _controller = new CategoryController(_categoryRepoMock.Object);
            var result = await _controller.Get();
            var obj = result as ObjectResult;
            Assert.AreEqual(400, obj.StatusCode);
        }
        [TestMethod]
        public async Task AddCategoryReturnOk()
        {
            var category = _fixture.Create<CategoryModel>();
            _categoryRepoMock.Setup(repo => repo.Put(It.IsAny<CategoryModel>())).Returns(category);
            _controller = new CategoryController(_categoryRepoMock.Object);
            var result = await _controller.Put(category);
            var obj = result as ObjectResult;
            Assert.AreEqual(200, obj.StatusCode);
        }
        [TestMethod]
        public async Task AddEmployeeThrowException()
        {
            _categoryRepoMock.Setup(repo => repo.Get()).Throws(new Exception());
            _controller = new CategoryController(_categoryRepoMock.Object);
            var result = await _controller.Get();
            var obj = result as ObjectResult;
            Assert.AreEqual(400, obj.StatusCode);
        }
        [TestMethod]
        public async Task UpdateCategoryReturnOk()
        {
            var category = _fixture.Create<CategoryModel>();
            _categoryRepoMock.Setup(repo => repo.Post(It.IsAny<CategoryModel>())).Returns(category);
            _controller = new CategoryController(_categoryRepoMock.Object);
            var result = await _controller.Post(category);
            var obj = result as ObjectResult;
            Assert.AreEqual(200, obj.StatusCode);
        }
        [TestMethod]
        public async Task UpdateEmployeeThrowException()
        {
            _categoryRepoMock.Setup(repo => repo.Get()).Throws(new Exception());
            _controller = new CategoryController(_categoryRepoMock.Object);
            var result = await _controller.Get();
            var obj = result as ObjectResult;
            Assert.AreEqual(400, obj.StatusCode);
        }
        [TestMethod]
        public async Task DeleteCategoryReturnOk()
        {
            var category = _fixture.Create<CategoryModel>();
            _categoryRepoMock.Setup(repo => repo.Delete(It.IsAny<int>())).Returns(true);
            _controller = new CategoryController(_categoryRepoMock.Object);
            var result = await _controller.Delete(It.IsAny<int>());
            var obj = result as ObjectResult;
            Assert.AreEqual(200, obj.StatusCode);
        }
        [TestMethod]
        public async Task DeleteCategoryThrowException()
        {
            _categoryRepoMock.Setup(repo => repo.Get()).Throws(new Exception());
            _controller = new CategoryController(_categoryRepoMock.Object);
            var result = await _controller.Get();
            var obj = result as ObjectResult;
            Assert.AreEqual(400, obj.StatusCode);
        }
    }
}
