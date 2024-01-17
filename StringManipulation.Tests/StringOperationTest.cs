using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringManipulation.Tests
{
    public class StringOperationTest
    {
        [Fact]
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

        [Fact]
        public void RemoveWhitespace()
        {
            var strOperations = new StringOperations();

            var result = strOperations.RemoveWhitespace("Hello World!");

            Assert.Equal("HelloWorld!", result);
        }

        [Fact]
        public void QuantintyInWords()
        {
            var strOperations = new StringOperations();

            var result = strOperations.QuantintyInWords("cat", 10);

            Assert.StartsWith("diez", result);    //  StartsWith("chars", stringEvaluated) -> Comprueba que stringEvaluated inicie con una combinación de caracteres en especifico (chars)
            Assert.Contains("cat", result);       //  Contains("chars", stringEvaluated) -> Comprueba que stringEvaluated contenga "chars" en alguna parte (no importa donde, como un '%LIKE%'
        }

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

        [Fact]
        public void TruncateString_Exception()
        {
            var strOperations = new StringOperations();

            Assert.ThrowsAny<ArgumentOutOfRangeException>(() => strOperations.TruncateString("abc", -1));
        }
    }
}
