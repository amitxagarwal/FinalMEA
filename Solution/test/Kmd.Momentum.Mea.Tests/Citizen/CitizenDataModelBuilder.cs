using Kmd.Momentum.Mea.Citizen.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kmd.Momentum.Mea.Tests.Citizen
{
    public class CitizenDataModelBuilder
    {
        private Guid id = Guid.NewGuid();
        private string displayName = "testBody";
        private string givenName = "testTitle";
        private string middleName = "testType";
        private string initials = "testType";
        private ContactInformation contactInformation = new ContactInformation()
        {
            Email  = new Email(){ Id = "test", Address = "test" },
            Phone = new Phone(){ Id = "test", IsMobile = true, Number = "test" }
        };
        private string caseworkerIdentifier = "testType";
        private string description = "description";
        private bool isBookable = true;
        private bool isActive = true;

        public CitizenDataModel Build()
        {
            return new CitizenDataModel(id, displayName, givenName, middleName, initials, contactInformation, caseworkerIdentifier, description, true, true);
        }

        public CitizenDataModelBuilder WithCpr(Guid id)
        {
            this.id = id;
            return this;
        }
        public CitizenDataModelBuilder WithDisplayName(string displayName)
        {
            this.displayName = displayName;
            return this;
        }
        public CitizenDataModelBuilder WithGivenName(string givenName)
        {
            this.givenName = givenName;
            return this;
        }
        public CitizenDataModelBuilder WithMiddleName(string middleName)
        {
            this.middleName = middleName;
            return this;
        }
        public CitizenDataModelBuilder Withinitials(string initials)
        {
            this.initials = initials;
            return this;
        }
        public CitizenDataModelBuilder WithContactInformation(ContactInformation contactInformation)
        {
            this.contactInformation = contactInformation;
            return this;
        }
      
        public CitizenDataModelBuilder WithCaseworkerIdentifier(string caseworkerIdentifier)
        {
            this.caseworkerIdentifier = caseworkerIdentifier;
            return this;
        }
        public CitizenDataModelBuilder WithDescription(string description)
        {
            this.description = description;
            return this;
        }
        public CitizenDataModelBuilder WithIsBookable(bool isBookable)
        {
            this.isBookable = isBookable;
            return this;
        }
        public CitizenDataModelBuilder WithIsActive(bool isActive)
        {
            this.isActive = isActive;
            return this;
        }
    }
}
