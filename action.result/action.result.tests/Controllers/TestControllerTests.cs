using System;
using action.result.Controllers;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace Tests.Controllers
{
    [TestClass]
    public class TestControllerTests
	{
        

        public TestControllerTests()
        {
            
        }

        [TestInitialize]
        public void Init()
        {

        }

        [TestCleanup]
        public void Dispose()
        {
            
        }

        [TestMethod]
        public void Testing_NotFound()
        {
            TestController controller = new TestController();

            // TODO Il faut éviter des faire des tests asynchrones, alors on ne fait pas
            // var actionResult = await controller.Testing(0);
            // Plutôt que d'utilisier await, on utilise .Result
            var actionResult = controller.Testing(0).Result;

            // TODO On converti le ActionResult en NotFoundResult, car l'action devrait faire
            // return NotFound();
            var result = actionResult.Result as NotFoundResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Testing_NotFound_BadTest()
        {
            TestController controller = new TestController();

            var actionResult = controller.Testing(200).Result;

            var result = actionResult.Result as NotFoundResult;

            // TODO Comme que le id est 200, l'action retourne
            // return Ok(200);
            // Alors la conversion en NotFoundResult donne une valeur null
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Testing_BadRequest()
        {
            TestController controller = new TestController();

            var actionResult = controller.Testing(1).Result;
            var result = actionResult.Result as BadRequestResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Testing_BadRequest_BadTest()
        {
            TestController controller = new TestController();

            var actionResult = controller.Testing(200).Result;

            var result = actionResult.Result as BadRequestResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Testing_Ok()
        {
            TestController controller = new TestController();

            var actionResult = controller.Testing(200).Result;
            // TODO On utilise un OkObjectResult plutôt que OkResult, puisqu'on retourne
            // return Ok(200);
            // Comme il y a une valeur dans le l'action result, on utilise la version
            // [Action]ObjectResult plutôt que juste [Action]Result
            var result = actionResult.Result as OkObjectResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.Value);
        }

        [TestMethod]
        public void Testing_Ok_BadTest()
        {
            TestController controller = new TestController();

            var actionResult = controller.Testing(1).Result;

            var result = actionResult.Result as OkObjectResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.Value);
        }

        [TestMethod]
        public void Testing_Ok_BadTest_NoValue()
        {
            TestController controller = new TestController();

            var actionResult = controller.Testing(1).Result;

            var result = actionResult.Result as OkResult;

            Assert.IsNotNull(result);
            // TODO on ne peut pas valider la valeur du retour
            // Assert.AreEqual(200, result.Value);
        }
    }
}

