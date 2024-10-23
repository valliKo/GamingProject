using FakeItEasy;
using FluentAssertions;
using GamingProject.Controllers;
using GamingProject.Model;
using GamingProject.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameProjectTest.ControllerTests
{
    public class GamesControllerTest
    {
        private readonly IGameInterface gameInterface;
        private readonly GamesController gamesController;
        public GamesControllerTest()
        {
            //set up dependencies
            this.gameInterface = A.Fake<IGameInterface>();

            // sut
            this.gamesController = new GamesController(gameInterface);
        }

        //create fake game details
        private static Game CreateFakeGame() => A.Fake<Game>();

        //create game details test

        [Fact]

        public async void GameController_CreateGame_Returns_true()
        {
            // Arrange
            var GameDetails = CreateFakeGame();

            //Act
            A.CallTo(()=> gameInterface.CreateAsync(GameDetails)).Returns(true);
            var result = (CreatedAtActionResult)await gamesController.Create(GameDetails);

            //Assert
            result.StatusCode.Should().Be(201);
            result.Should().NotBeNull();
        }

        [Fact]

        public async void GameController_GetAllGameDeatails_Returns_Ok()
        {
            // Arrange
            var GameDetails = A.Fake<List<Game>>();
            GameDetails.Add(new Game() { Title = "FakeName", Description = "FakeDetails" });

            //Act
            A.CallTo(() => gameInterface.GetAllAsync()).Returns(GameDetails);
            var result = (OkObjectResult)await gamesController.GetGames();

            //Assert
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
            result.Should().NotBeNull();
        }

        [Fact]

        public async void GameController_UpdateGame_Returns_true()
        {
            // Arrange
            var GameDetails = CreateFakeGame();

            //Act
            A.CallTo(() => gameInterface.UpdateAsync(GameDetails)).Returns(true);
            var result = (OkResult)await gamesController.UpdateGameeDetails(GameDetails);

            //Assert
            result.StatusCode.Should().Be(200);
            result.Should().NotBeNull();
        }

        [Theory]
        [InlineData(1)]
        public async void GameController_DeleteGame_ReturnsNoContent(int id)
        {
           
            //Act
            A.CallTo(() => gameInterface.DeleteAsync(id)).Returns(true);
            var result = (NoContentResult)await gamesController.DeleteGame(id);

            //Assert
            result.StatusCode.Should().Be(StatusCodes.Status204NoContent);
            result.Should().NotBeNull();
        }

        [Theory]
        [InlineData(1,1)]
        public async void GameController_GetGameDetails_ByPage_ReturnsOk(int pageIndex, int pageSize)
        {
            // Arrange
            var GameDetails = A.Fake<PaginatedList<Game>>();
            GameDetails.Items.Add(new Game() { Title = "FakeName", Description = "FakeDetails" });

            //Act
            A.CallTo(() => gameInterface.GetGames(pageIndex,pageSize)).Returns(GameDetails);
            var result = (OkObjectResult)await gamesController.GetGameDetailsByPage(pageIndex,pageSize);

            //Assert
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
            result.Should().NotBeNull();
        }
    }
}
