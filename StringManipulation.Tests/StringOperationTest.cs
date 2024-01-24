using Humanizer;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringManipulation.Tests
{
    public class StringOperationTest
    {
        //  [Fact(Skip = "Esta prueba no es valida en este momento, TICKET-001")]   //  Skip = "message" -> Omite la ejecución de la prueba
        public void ConcatenateStrings()
        {
            //  Arrange
            var strOperations = new StringOperations();

            //  Act
            var result = strOperations.ConcatenateStrings("Hello", "World!");

            //  Assert
            Assert.NotNull(result); //  Assert -> Clase de xUnit que permite realizar afirmaciones en el código de prueba
                                    //      NotNull(result) -> Valida que un resultado no sea null
            Assert.NotEmpty(result);    //  NotEmpty(result) -> Valida que el resultado no sera vacio
            Assert.Equal("Hello World!", result);   //  Equal(expectedResult, result) -> Permite enviar un resultado esperado para un metodo y el resultado real devuelto por el metodo para evaluar si ambos son iguales
        }

        [Fact]
        public void ReverseString()
        {
            var strOperations = new StringOperations();

            var result = strOperations.ReverseString("hello");

            Assert.Equal(result, "olleh");
        }

        /*
        [Fact]
        public void IsPalindrome_True()
        {
            var strOperations = new StringOperations();

            var result = strOperations.IsPalindrome("ama");

            Assert.True(result);    //  True(result) -> Valida que la funcion retorne True
        }

        [Fact]
        public void IsPalindrome_False()
        {
            var strOperations = new StringOperations();

            var result = strOperations.IsPalindrome("hello");

            Assert.False(result);    //  False(result) -> Valida que la funcion retorne False
        }
        */

        [Fact]
        public void RemoveWhitespace()
        {
            var strOperations = new StringOperations();

            var result = strOperations.RemoveWhitespace("Hello World!");

            Assert.Equal("HelloWorld!", result);
        }

        /*
        [Fact]
        public void QuantintyInWords()
        {
            var strOperations = new StringOperations();

            var result = strOperations.QuantintyInWords("cat", 10);

            Assert.StartsWith("diez", result);    //  StartsWith("chars", stringEvaluated) -> Comprueba que stringEvaluated inicie con una combinación de caracteres en especifico (chars)
            Assert.Contains("cat", result);       //  Contains("chars", stringEvaluated) -> Comprueba que stringEvaluated contenga "chars" en alguna parte (no importa donde, como un '%LIKE%'
        }
        */

        [Fact]
        public void GetStringLength()
        {
            var strOperations = new StringOperations();

            var result = strOperations.GetStringLength("12345");

            Assert.Equal(5, result);
        }

        [Fact]
        public void GetStringLength_Exception()
        {
            var strOperations = new StringOperations();

            Assert.ThrowsAny<ArgumentNullException>(() => strOperations.GetStringLength(null)); //  ThrowsAny<Exception>(() => object.method()) -> Verifica que el metodo arroje una excepcion
        }

        //[Fact]
        //public void TruncateString()
        //{
        //    var strOperations = new StringOperations();

        //    var result = strOperations.TruncateString();
        //}

        [Theory]
        [InlineData(null, 1, null)]
        [InlineData("Hello", 3, "Hel")]
        [InlineData("Hello", 10, "Hello")]
        public void TruncateString_NullMaxLength(string input, int maxLength, string expected)
        {
            var strOperations = new StringOperations();

            var result = strOperations.TruncateString(input, maxLength);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("Hello", 3, "Hel")]
        [InlineData("Hello", 10, "Hello")]
        public void TruncateString_MaxLength(string input, int maxLength, string expected)
        {
            var strOperations = new StringOperations();

            var result = strOperations.TruncateString(input, maxLength);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void TruncateString_Exception()
        {
            var strOperations = new StringOperations();

            Assert.ThrowsAny<ArgumentOutOfRangeException>(() => strOperations.TruncateString("abc", -1));
        }

        [Theory]    //  [Theory] -> Especifica que la prueba será ejecutada con diferentes escenarios (mediante la recepcion de parametros)
        [InlineData("V", 5)]    //  [InlineData(attributes... )] -> Configura atributos de entrada para diferentes escenarios en una prueba [Theory]
        [InlineData("III", 3)]
        [InlineData("X", 10)]
        public void FromRomanToNumber(string romanNumber, int expected)
        {
            var strOperations = new StringOperations();

            var result = strOperations.FromRomanToNumber(romanNumber);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("carro", 7, "siete carros")]
        [InlineData("camion", 10, "diez camions")]
        public void QuantintyInWords(string input, int quiantity, string expected)
        {
            var strOperations = new StringOperations();

            var result = strOperations.QuantintyInWords(input, quiantity);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("ama", true)]
        [InlineData("mamá", false)]
        public void IsPalindrome(string input, bool expected)
        {
            var strOperations = new StringOperations();

            var result = strOperations.IsPalindrome(input);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void CountOccurrences()
        {
            var mockLogger = new Mock<ILogger<StringOperations>>(); //  Mock<objectMock>(); -> Crea un mock de objectMock
            var strOperations = new StringOperations(mockLogger.Object);    //  mockObject.Object -> Obtiene el objeto simulado por el mock

            var result = strOperations.CountOccurrences("Hello Platzi", 'l');

            Assert.Equal(3, result);
        }

        [Fact]
        public void ReadFile()
        {
            var strOperations = new StringOperations();
            var mockFileReader = new Mock<IFileReaderConector>();

            //  mockFileReader.Setup(p => p.ReadString("file.txt")).Returns("Reading file");  //  Setup(p => p.Method()).Returns(valueToReturn) -> Permite configurar funciones para un mock especificando lo que deben retornar
            mockFileReader.Setup(p => p.ReadString(It.IsAny<string>())).Returns("Reading file");    //  It.IsAny<dataType>() -> Especifica que el parametro recibido puede tener cualquier valor, siempre y cuando sea del tipo dataType

            var result = strOperations.ReadFile(mockFileReader.Object, "asdfasdfadsf.txt");

            Assert.Equal("Reading file", result);
        }
    }
}
