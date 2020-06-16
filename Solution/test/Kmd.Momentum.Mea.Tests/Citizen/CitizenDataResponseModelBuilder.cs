using Kmd.Momentum.Mea.Citizen.Model;
using Moq;
using System;

namespace Kmd.Momentum.Mea.Tests.Citizen
{
    public class CitizenDataResponseModelBuilder
    {
        private Guid CitizenId = It.IsAny<Guid>();
        private string DisplayName = "testBody";
        private string GivenName = "testTitle";
        private string MiddleName = "testType";
        private string Initials = "testType";
        private string Email = "test";
        private string Phone = "test";
        private string CaseworkerIdentifier = "testType";
        private string Description = "description";
        private bool IsBookable = true;
        private bool IsActive = true;

        public CitizenDataResponseModel Build()
        {
            return new CitizenDataResponseModel(CitizenId, DisplayName, GivenName, MiddleName, Initials, Email, Phone, CaseworkerIdentifier, Description, true, true);
        }

        public CitizenDataResponseModelBuilder WithCitizenId(Guid citizenId)
        {
            this.CitizenId = citizenId;
            return this;
        }
        public CitizenDataResponseModelBuilder WithDisplayName(string displayName)
        {
            this.DisplayName = displayName;
            return this;
        }
        public CitizenDataResponseModelBuilder WithGivenName(string givenName)
        {
            this.GivenName = givenName;
            return this;
        }
        public CitizenDataResponseModelBuilder WithMiddleName(string middleName)
        {
            this.MiddleName = middleName;
            return this;
        }
        public CitizenDataResponseModelBuilder Withinitials(string initials)
        {
            this.Initials = initials;
            return this;
        }
        public CitizenDataResponseModelBuilder WithEmail(string email)
        {
            this.Email = email;
            return this;
        }
        public CitizenDataResponseModelBuilder WithPhone(string phone)
        {
            this.Phone = phone;
            return this;
        }
        public CitizenDataResponseModelBuilder WithCaseworkerIdentifier(string caseworkerIdentifier)
        {
            this.CaseworkerIdentifier = caseworkerIdentifier;
            return this;
        }
        public CitizenDataResponseModelBuilder WithDescription(string description)
        {
            this.Description = description;
            return this;
        }
        public CitizenDataResponseModelBuilder WithIsBookable(bool isBookable)
        {
            this.IsBookable = isBookable;
            return this;
        }
        public CitizenDataResponseModelBuilder WithIsActive(bool isActive)
        {
            this.IsActive = isActive;
            return this;
        }
    }
}
