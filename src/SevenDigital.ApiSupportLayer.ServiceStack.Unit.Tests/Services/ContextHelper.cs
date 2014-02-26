﻿using System.Collections.Specialized;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface;
using ServiceStack.ServiceInterface.Auth;
using ServiceStack.ServiceInterface.Testing;
using SevenDigital.ApiSupportLayer.TestData;

namespace SevenDigital.ApiSupportLayer.ServiceStack.Unit.Tests.Services
{
	public static class ContextHelper
	{
		public static MockRequestContext LoggedInContext()
		{
			var mockRequestContext = new MockRequestContext();
			var httpReq = (MockHttpRequest)mockRequestContext.Get<IHttpRequest>();
			httpReq.RemoteIp = "86.131.235.233, 127.0.0.1";
			var httpRes = mockRequestContext.Get<IHttpResponse>();
			var authUserSession = mockRequestContext.ReloadSession();
			authUserSession.Id = httpRes.CreateSessionId(httpReq);
			authUserSession.IsAuthenticated = true;
			authUserSession.ProviderOAuthAccess.Add(new OAuthTokens { AccessToken = FakeUserData.FakeAccessToken.Token, AccessTokenSecret = FakeUserData.FakeAccessToken.Secret });
			httpReq.Items[ServiceExtensions.RequestItemsSessionKey] = authUserSession;
			return mockRequestContext;
		}

		public static MockRequestContext LoggedInContext(NameValueCollection formData)
		{
			var mockRequestContext = new MockRequestContext();
			var httpReq = (MockHttpRequest)mockRequestContext.Get<IHttpRequest>();
			httpReq.RemoteIp = "86.131.235.233, 127.0.0.1";
			var httpRes = mockRequestContext.Get<IHttpResponse>();
			var authUserSession = mockRequestContext.ReloadSession();
			authUserSession.Id = httpRes.CreateSessionId(httpReq);
			authUserSession.IsAuthenticated = true;
			authUserSession.ProviderOAuthAccess.Add(new OAuthTokens { AccessToken = FakeUserData.FakeAccessToken.Token, AccessTokenSecret = FakeUserData.FakeAccessToken.Secret });
			httpReq.Items[ServiceExtensions.RequestItemsSessionKey] = authUserSession;
			httpReq.FormData = formData;
			return mockRequestContext;
		}
	}
}