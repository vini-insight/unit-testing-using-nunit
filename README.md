Tutorial: https://docs.microsoft.com/pt-br/dotnet/core/testing/unit-testing-with-nunit

1º - criar dirtório chamado "unit-testing-using-nunit".

2º - entrar na pasta:

    cd unit-testing-using-nunit

3º - criar solution:

    dotnet new sln

4º - criar dirtório chamado "PrimeService".

5º - entrar na pasta:

    cd PrimeService

6º - criar novo projeto com mesmo nome da pasta:

    dotnet new classlib

7º - renomear Class1.cs para PrimeService.cs e crie uma implementação com falha da classe:

    using System;
    namespace PrimeServices
    {
        public class PrimeService
        {
            public bool IsPrime(int candidate)
            {
                throw new NotImplementedException("Please create a test first.");
            }
        }
    }

8º - retorne para o diretório "unit-testing-using-nunit":

    cd ..

9º - Execute o seguinte comando para adicionar o projeto de biblioteca de classes à solução:

    dotnet sln add PrimeService/PrimeService.csproj

10º - Criando o projeto de teste. Crie o diretório PrimeServiceTests

11º - entrar na pasta:

    cd PrimeServiceTests

12º - criar novo projeto de Testes usando NUnit com mesmo nome da pasta:

    dotnet new nunit

13º -  Agora, adicione a biblioteca de classes PrimeService como outra dependência ao projeto de Testes. Use o comando:

    dotnet add reference ../PrimeService/PrimeService.csproj

14º - O seguinte esquema mostra o layout da solução final:

    /unit-testing-using-nunit
        unit-testing-using-nunit.sln
        /PrimeService
            Source Files
            PrimeService.csproj
        /PrimeServiceTests
            Test Source Files
            PrimeServiceTests.csproj

15º - Agora é necessário adicionar o projeto de testes na solution. Para isso, retorne ao diretório principal "unit-testing-using-nunit" e execute o seguinte comando:

    dotnet sln add ./PrimeServiceTests/PrimeServiceTests.csproj

16º - Criando o primeiro teste. Escreva um teste com falha, faça-o ser aprovado e, em seguida, repita o processo. No diretório PrimeServiceTests, renomeie o arquivo UnitTest1.cs para PrimeService_IsPrimeShould.cs e substitua todo o seu conteúdo pelo código a seguir:

    using NUnit.Framework;
    using PrimeServices;

    namespace PrimeServiceTests
    {
        [TestFixture]
        public class PrimeService_IsPrimeShould
        {
            private PrimeService _primeService;

            [SetUp]
            public void SetUp()
            {
                _primeService = new PrimeService();
            }

            [Test]
            public void IsPrime_InputIs1_ReturnFalse()
            {
                var result = _primeService.IsPrime(1);

                Assert.IsFalse(result, "1 should not be prime");
            }
        }
    }

17º - O atributo [TestFixture] indica uma classe que contém testes de unidade. O atributo [Test] indica um método que é um método de teste.
Salve esse arquivo e execute dotnet test para compilar os testes e a biblioteca de classes e, em seguida, execute os testes. O executor de teste do NUnit contém o ponto de entrada do programa para executar os testes. dotnet test inicia o executor de teste usando o projeto de teste de unidade que você criou.
O teste falha. Você ainda não criou a implementação.

OBS.: no CLI este comando funciona tanto na pasta da solution quanto na pasta do projeto de teste.

    dotnet test

18º - Faça esse teste ser aprovado escrevendo o código mais simples na classe PrimeService que funciona:

    public bool IsPrime(int candidate)
    {
        if (candidate == 1)
        {
            return false;
        }
        throw new NotImplementedException("Please create a test first.");
    }


19º - Execute "dotnet test" novamente. Ele executa uma compilação para o projeto PrimeService e, depois, para o projeto PrimeServiceTests. Depois de compilar os dois projetos, ele executará esse teste único. Ele é aprovado.

