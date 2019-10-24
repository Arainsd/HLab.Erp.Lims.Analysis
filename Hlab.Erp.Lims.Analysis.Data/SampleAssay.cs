using System.ComponentModel.DataAnnotations.Schema;
using HLab.DependencyInjection.Annotations;
using HLab.Erp.Data;
using HLab.Erp.Data.Observables;
using HLab.Notify;
using HLab.Notify.Annotations;
using HLab.Notify.PropertyChanged;
using NPoco;

namespace HLab.Erp.Lims.Analysis.Data
{
    public partial class SampleAssay : Entity<SampleAssay>
        , IEntityWithIcon
        , IEntityWithColor
    {
        public int? SampleId
        {
            get => _sampleId.Get();
            set => _sampleId.Set(value);
        }
        private readonly IProperty<int?> _sampleId = H.Property<int?>();


        public int? AssayClassId
        {
            get => _assayClassId.Get();
            set => _assayClassId.Set(value);
        }
        private readonly IProperty<int?> _assayClassId = H.Property<int?>();


        public int? AssayStateId
        {
            get => _assayStateId.Get();
            set => _assayStateId.Set(value);
        }
        private readonly IProperty<int?> _assayStateId = H.Property<int?>();


        public int? UserId
        {
            get => _userId.Get();
            set => _userId.Set(value);
        }
        private readonly IProperty<int?> _userId = H.Property<int?>();


        public string Method { get; set; }

        public int? PurposeId
        {
            get => _purposeId.Get();
            set => _purposeId.Set(value);
        }
        private readonly IProperty<int?> _purposeId = H.Property<int?>();


        public string Note { get; set; }

        public int? Validation
        {
            get => _validation.Get();
            set => _validation.Set(value);
        }
        private readonly IProperty<int?> _validation = H.Property<int?>();


        public int? ValidatorId
        {
            get => _validatorId.Get();
            set => _validatorId.Set(value);
        }
        private readonly IProperty<int?> _validatorId = H.Property<int?>();


        //[Column]
        //public DateTime? DateValidation
        //{
        //    get => N.Get(() => (DateTime?)null); set => N.Set(value);
        //}


        public string AssayName
        {
            get => _assayName.Get();
            set => _assayName.Set(value);
        }
        private readonly IProperty<string> _assayName = H.Property<string>(c => c.Default(""));


        public string Version
        {
            get => _version.Get();
            set => _version.Set(value);
        }
        private readonly IProperty<string> _version = H.Property<string>(c => c.Default(""));


        //[StringLength(16777215)]
        //public string Cs1 { get; set; }

        //[StringLength(16777215)]
        //public string Xaml1 { get; set; }

        public byte[] Code
        {
            get => _code.Get(); 
            set => _code.Set(value);
        }
        private readonly IProperty<byte[]> _code = H.Property<byte[]>();

        public string Description
        {
            get => _description.Get();
            set => _description.Set(value);
        }
        private readonly IProperty<string> _description = H.Property<string>(c => c.Default(""));


        public string Specification
        {
            get => _specification.Get();
            set => _specification.Set(value);
        }
        private readonly IProperty<string> _specification = H.Property<string>(c => c.Default(""));


        public string Conform
        {
            get => _conform.Get();
            set => _conform.Set(value);
        }
        private readonly IProperty<string> _conform = H.Property<string>(c => c.Default(""));

        public string Result
        {
            get => _result.Get();
            set => _result.Set(value);
        }
        private readonly IProperty<string> _result = H.Property<string>(c => c.Default(""));

        //[Column("DateDebut")]
        //public DateTime? StartDate
        //{
        //    get => N.Get(() => (DateTime?)null); set => N.Set(value);
        //}


        //[Column("DateFin")]
        //public DateTime? EndDate
        //{
        //    get => N.Get(() => (DateTime?)null); set => N.Set(value);
        //}


        public bool? ReTest
        {
            get => _reTest.Get();
            set => _reTest.Set(value);
        }
        private readonly IProperty<bool?> _reTest = H.Property<bool?>();


        public string OosNo
        {
            get => _oosNo.Get();
            set => _oosNo.Set(value);
        }
        private readonly IProperty<string> _oosNo = H.Property<string>(c => c.Default(""));

        public int? Order
        {
            get => _order.Get();
            set => _order.Set(value);
        }
        private readonly IProperty<int?> _order = H.Property<int?>();

        //[LOG 24]\nNom=Etape\nId=0 : Saisie du test\nId=1 : Test norm�\nId=2 : A faire\nId=3 : En cours\nId=4 : Valid� par le technicien\nId=5 : Donn�es brutes valid�es\nId=6 : Valid� par le pharmacien
        public int? Stage
        {
            get => _stage.Get();
            set => _stage.Set(value);
        }
        private readonly IProperty<int?> _stage = H.Property<int?>();

        [Ignore]
        public virtual Sample Sample
        {
            //get => E.GetForeign<Sample>(() => SampleId);
            set => SampleId = value.Id;
            get => _sample.Get();
            //set => _sample.Set(value);
        }
        private readonly IProperty<Sample> _sample = H.Property<Sample>(c => c.Foreign(e => e.SampleId));

        [Ignore]
        public virtual AssayClass AssayClass
        {
            set => AssayClassId = value.Id;
            get => _assayClass.Get();
        }
        private readonly IProperty<AssayClass> _assayClass = H.Property<AssayClass>(c => c
            .Foreign(e => e.AssayClassId)
        );

        [Ignore]
        public int? Color => _color.Get();
        private readonly IProperty<int?> _color = H.Property<int?>(c => c
            .On(e => e.AssayClass.Color)
            .Set(e => e.AssayClass?.Color)
        );


        [Ignore]
        public string IconPath => _iconPath.Get();
        private IProperty<string> _iconPath = H.Property<string>(c => c
            .OneWayBind(e => e.AssayClass.IconPath)
        );

        [Ignore]
        public ObservableQuery<AssayResult> AssayResults => _sampleAssays.Get();
        private readonly IProperty<ObservableQuery<AssayResult>> _sampleAssays = H.Property<ObservableQuery<AssayResult>>(c => c
            .Foreign(e => e.SampleAssayId)
        );

        //[Ignore]
        //[Import]
        //public ObservableQuery<AssayResult> AssayResults
        //{
        //    get => N.Get<ObservableQuery<AssayResult>>();
        //    set => N.Set(value.AddFilter("OneToMany", e => e.SampleAssayId == Id)
        //        .FluentUpdate());
        //}
    }
}
