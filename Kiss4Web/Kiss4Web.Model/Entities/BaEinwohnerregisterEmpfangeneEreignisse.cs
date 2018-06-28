using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class BaEinwohnerregisterEmpfangeneEreignisse
    {
        public int BaEinwohnerregisterEmpfangeneEreignisseId { get; set; }
        public int BaEinwohnerregisterEmpfangeneEreignisseRohdatenId { get; set; }
        public string FremdsystemId { get; set; }
        public string DeliveryHeader { get; set; }
        public string Absence { get; set; }
        public string Acknowledgement { get; set; }
        public string AddressLock { get; set; }
        public string Adoption { get; set; }
        public string Birth { get; set; }
        public string Care { get; set; }
        public string ChildRelationship { get; set; }
        public string Contact { get; set; }
        public string Death { get; set; }
        public string DeletePerson { get; set; }
        public string Divorce { get; set; }
        public string GardianMeasure { get; set; }
        public string MaritalStatusPartner { get; set; }
        public string Marriage { get; set; }
        public string Missing { get; set; }
        public string Move { get; set; }
        public string MoveIn { get; set; }
        public string MoveOut { get; set; }
        public string NaturalizeForeigner { get; set; }
        public string NaturalizeSwiss { get; set; }
        public string PaperLock { get; set; }
        public string Partnership { get; set; }
        public string RenewPermit { get; set; }
        public string ReplacePerson { get; set; }
        public string Separation { get; set; }
        public string ChangeCitizen { get; set; }
        public string ChangeGardian { get; set; }
        public string ChangeName { get; set; }
        public string ChangeNationality { get; set; }
        public string ChangeNestRegister { get; set; }
        public string ChangeNestTarget { get; set; }
        public string ChangeOccupation { get; set; }
        public string ChangeOkv { get; set; }
        public string ChangeReligion { get; set; }
        public string ChangeResidencePermit { get; set; }
        public string ChangeResidenceType { get; set; }
        public string ChangeSex { get; set; }
        public string CorrectAbsence { get; set; }
        public string CorrectAdditionalAddresses { get; set; }
        public string CorrectAddress { get; set; }
        public string CorrectCodes { get; set; }
        public string CorrectContact { get; set; }
        public string CorrectDateOfDeath { get; set; }
        public string CorrectDateOfNameChange { get; set; }
        public string CorrectDateOfNaturalization { get; set; }
        public string CorrectDmp { get; set; }
        public string CorrectIdentification { get; set; }
        public string CorrectLanguageOfCorrespondance { get; set; }
        public string CorrectLiabilities { get; set; }
        public string CorrectMaritalData { get; set; }
        public string CorrectName { get; set; }
        public string CorrectNationality { get; set; }
        public string CorrectOccupation { get; set; }
        public string CorrectOrigin { get; set; }
        public string CorrectPerson { get; set; }
        public string CorrectPlaceOfBirth { get; set; }
        public string CorrectRelationship { get; set; }
        public string CorrectReligion { get; set; }
        public string CorrectReporting { get; set; }
        public string CorrectResidencePermit { get; set; }
        public string UndoAbsence { get; set; }
        public string UndoCitizen { get; set; }
        public string UndoGardian { get; set; }
        public string UndoMarriage { get; set; }
        public string UndoMissing { get; set; }
        public string UndoPartnership { get; set; }
        public string UndoSeparation { get; set; }
        public string UndoSwiss { get; set; }
        public string BaseDeliveryNumberOfMessages { get; set; }
        public string BaseDeliveryMessages { get; set; }
        public string KeyDeliveryNumberOfKeyMessages { get; set; }
        public string KeyDeliveryMessages { get; set; }
        public string DataRequest { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] BaEinwohnerregisterEmpfangeneEreignisseTs { get; set; }

        public BaEinwohnerregisterEmpfangeneEreignisseRohdaten BaEinwohnerregisterEmpfangeneEreignisseRohdaten { get; set; }
    }
}
