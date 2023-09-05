using NetArchTest.Rules;
using Shouldly;
using System.Reflection;

namespace Todo.Architecture.Test
{
    public class ArchitectureTest
    {
        private const string DomainNamespace = "Todo.Domain";
        private const string ApplicationNamespace = "Todo.Application";
        private const string IdentityNamespace = "Todo.Idenity";
        private const string PersisteceNamespace = "Todo.Persistence";
        private const string APINamespace = "Todo.API";
        [Fact]
        public void Domain_Should_Not_HaveDependencyOnOtherProjects()
        {
            var assembly = Assembly.Load(DomainNamespace);

            var otherProjects = new[]
            {
                ApplicationNamespace,
                IdentityNamespace,
                APINamespace,
                PersisteceNamespace,
            };

            var result = Types
                .InAssembly(assembly)
                .ShouldNot()
                .HaveDependencyOnAll(otherProjects)
                .GetResult();

            result.IsSuccessful.ShouldBe(true);
        }

        [Fact]
        public void Appliction_Should_Not_HaveDepedenacyOnOtherProjects()
        {
            //Arrange
            var assembly = Assembly.Load(ApplicationNamespace);

            var otherProjects = new[]
            {
                IdentityNamespace,
                PersisteceNamespace,
                APINamespace
            };

            //Act
            var result = Types
                .InAssembly(assembly)
                .ShouldNot()
                .HaveDependencyOnAll(otherProjects)
                .GetResult();


            //Assert
            result.IsSuccessful.ShouldBe(true);
        }

        [Fact]
        public void Identity_Should_Not_HaveDepedenacyOnOtherProjects()
        {
            //Arrange
            var assembly = Assembly.Load(IdentityNamespace);

            var otherProjects = new[]
            {
                APINamespace
            };

            //Act
            var result = Types
                .InAssembly(assembly)
                .ShouldNot()
                .HaveDependencyOnAll(otherProjects)
                .GetResult();


            //Assert
            result.IsSuccessful.ShouldBe(true);
        }

        [Fact]
        public void Persistence_Should_Not_HaveDepedenacyOnOtherProjects()
        {
            //Arrange
            var assembly = Assembly.Load(PersisteceNamespace);

            var otherProjects = new[]
            {
                APINamespace
            };

            //Act
            var result = Types
                .InAssembly(assembly)
                .ShouldNot()
                .HaveDependencyOnAll(otherProjects)
                .GetResult();


            //Assert
            result.IsSuccessful.ShouldBe(true);
        }
    }
}