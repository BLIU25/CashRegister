using Moq;

namespace CashRegisterTest
{
	using CashRegister;
	using Xunit;

	public class CashRegisterTest
	{
		[Fact]
		public void Should_process_execute_printing()
		{
			//given
            SpyPrinter printer = new SpyPrinter();
			var cashRegister = new CashRegister(printer);
			var purchase = new Purchase();
			//when
			cashRegister.Process(purchase);
			//then
			//verify that cashRegister.process will trigger print
			Assert.True(printer.HasPrinted);
		}

        [Fact]
        public void Should_call_print_when_execute_process()
        {
            //given

            var spySpyPrinter = new Mock<Printer>();
            var cashRegister = new CashRegister(spySpyPrinter.Object);
            var purchase = new Purchase();
            //when
            cashRegister.Process(purchase);
            //then
            //verify that cashRegister.process will trigger print
            spySpyPrinter.Verify(_ => _.Print(It.IsAny<string>()));
        }
    }
}
