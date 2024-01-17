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
    }
}
