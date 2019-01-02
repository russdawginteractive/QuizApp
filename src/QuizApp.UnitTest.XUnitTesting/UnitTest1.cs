using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Linq;
using Xunit;

namespace QuizApp.UnitTest.XUnitTesting
{
	public class UnitTest1
	{
		[Fact]
		public void TestMethod1()
		{
		}
		//private Mock<SignInManager<IdentityUser>> GetMockSignInManager()
		//{
		//	var mockUsrMgr = new UserManager<IdentityUser>(userStoreMock.Object, null, null, null, null, null, null, null, null);
		//	var ctxAccessor = new HttpContextAccessor();
		//	var mockClaimsPrinFact = new Mock<IUserClaimsPrincipalFactory<IdentityUser>>();
		//	var mockOpts = new Mock<IOptions<IdentityOptions>>();
		//	var mockLogger = new Mock<ILogger<SignInManager<IdentityUser>>>();

		//	return new Mock<SignInManager<IdentityUser>>(mockUsrMgr.Object, ctxAccessor, mockClaimsPrinFact.Object, mockOpts.Object, mockLogger.Object);
		//}
	}
}
