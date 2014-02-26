using System;
using SevenDigital.Api.Schema.ParameterDefinitions.Post;
using SevenDigital.ApiSupportLayer.Mapping;
using SevenDigital.ApiSupportLayer.ServiceStack.Model;

namespace SevenDigital.ApiSupportLayer.ServiceStack.Mapping
{
	public class AddCardMapper : IMapper<AddCardRequest, AddCardParameters>
	{
		public AddCardParameters Map(AddCardRequest input)
		{
			var addCardParameters = new AddCardParameters
			{
				ExpiryDate = input.ExpiryDate,
				HolderName = input.HolderName,
				Number = input.Number,
				PostCode = input.PostCode,
				TwoLetterISORegionName = input.TwoLetterISORegionName,
				Type = input.Type,
				VerificationCode = input.VerificationCode
			};

			if (!string.IsNullOrEmpty(input.IssueNumber))
			{
				int issueNum;
				int.TryParse(input.IssueNumber, out issueNum);
				addCardParameters.IssueNumber = issueNum;
			}

			if (input.StartDate > DateTime.MinValue)
			{
				addCardParameters.StartDate = input.StartDate;
			}

			return addCardParameters;
		}
	}
}