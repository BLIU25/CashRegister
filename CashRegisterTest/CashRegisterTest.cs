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

        [Fact]
        public void Should_print_purchase_content_when_run_process_given_stub_purchase()
        {
            //given

            var spySpyPrinter = new Mock<Printer>();
            var cashRegister = new CashRegister(spySpyPrinter.Object);
            var stubStubPurchase = new Mock<Purchase>();
            stubStubPurchase.Setup(x => x.AsString()).Returns("moq content");
            //when
            cashRegister.Process(stubStubPurchase.Object);
            //then
            spySpyPrinter.Verify(_ => _.Print("moq content"));
        }

        [Fact]
        public void Should_throw_hardware_exception_when_run_process()
        {
            //given
            var stubPrinter = new Mock<Printer>();
            stubPrinter.Setup(_ => _.Print(It.IsAny<string>())).Throws<PrinterOutOfPaperException>();
            var cashRegister = new CashRegister(stubPrinter.Object);
            //when
            // cashRegister.Process(purchase);
            //then
            Assert.Throws<HardwareException>(() => cashRegister.Process(new Purchase()));
        }
    }
}
