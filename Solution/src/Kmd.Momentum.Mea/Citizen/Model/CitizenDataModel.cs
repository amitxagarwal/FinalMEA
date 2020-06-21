using System;

namespace Kmd.Momentum.Mea.Citizen.Model
{
    public class CitizenDataModel
    {
        public Guid Id { get; }

        public string DisplayName { get; }

        public string GivenName { get; }

        public string MiddleName { get; }

        public string Initials { get; }

        public ContactInformation ContactInformation { get; }

        public string CaseworkerIdentifier { get; }

        public string Description { get; }

        public bool IsBookable { get; }

        public bool IsActive { get; }

        public CitizenDataModel(Guid id, string displayName, string givenName, string middleName, string initials,
           ContactInformation contactInformation, string caseworkerIdentifier, string description,
           bool isActive = true, bool isBookable = true)
        {
            Id = id;
            DisplayName = displayName;
            GivenName = givenName;
            MiddleName = middleName;
            Initials = initials;
            ContactInformation = contactInformation;
            CaseworkerIdentifier = caseworkerIdentifier;
            Description = description;
            IsBookable = isBookable;
            IsActive = isActive;
        }
    }
}

