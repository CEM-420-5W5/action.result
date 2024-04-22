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

            // TODO Pour éviter des faire des tests asynchrones, on peut utiliser .Result
            // Plutôt que d'utilisier await (Mais on évite dans le code normal, car ça bloque le thread)
            var actionResult = controller.Testing(0).Result;


            // TODO On converti le ActionResult en NotFoundResult, car l'action devrait faire
            // return NotFound();
            var result = actionResult.Result as NotFoundResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Testing_BadRequest()
        {
            TestController controller = new TestController();

            // Le code du contrôleur retourne un BadRequest si l'Id est 1 (hardcodé)
            var actionResult = controller.Testing(1).Result;
            var result = actionResult.Result as BadRequestResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Testing_Ok()
        {
            TestController controller = new TestController();

            var actionResult = controller.Testing(42).Result;
            // TODO On utilise un OkObjectResult plutôt que OkResult, puisqu'on retourne
            // return Ok(42);
            // Comme il y a une valeur dans le l'action result, on utilise la version
            // [Action]ObjectResult plutôt que juste [Action]Result
            OkObjectResult? result = actionResult.Result as OkObjectResult;

            Assert.IsNotNull(result);
            // Avec un OkObjectResult, on peut accéder à la valeur
            Assert.AreEqual(42, result.Value);

            // ATTENTION, en utilisant Ok(x), l'objet est OkObjectResult et n'est PAS un OkResult (en utilisant simplement Ok())
            var resultWithoutObject = actionResult.Result as OkResult;
            // ICI, on montre que le Result n'est PAS un OkResult (Pas nécessaire de le faire à chaque fois, c'est seulement pour la démonstration)
            Assert.IsNull(resultWithoutObject);
        }
    }
}

