using AutoMapper;

namespace CratiaApp.Bussines.Logic.AutoMapperConfiguration
{
    internal class SharedAutoMapperConfiguration
    {
        public SharedAutoMapperConfiguration(IMapperConfigurationExpression cfg)
        {
            RegisterToDTOMappings(cfg);
            RegisterToEFEntitiesMappings(cfg);
        }

        private void RegisterToDTOMappings(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Test, ExamTestDTO>()
                .ForMember(dto => dto.Answers, t => t.PreCondition(d => d.Type != TestType.OpenAnswer));

            cfg.CreateMap<Answer, ExamAnswerDTO>();

            cfg.CreateMap<Payment, PaymentInfo>()
                .ForMember(dto => dto.PaymentType, p => p.MapFrom(d => d.Type))
                .ForMember(dto => dto.PaymentStatus, p => p.MapFrom(d => d.Status))
                .ForMember(dto => dto.Product, p => p.MapFrom(d => d.Product.Name))
                .ForMember(dto => dto.UserName, p => p.MapFrom(d => d.User.UserName))
                .ForMember(dto => dto.DiscountCode, p => p.MapFrom(d => d.Discount != null ? d.Discount.Code : null))
                .ForMember(dto => dto.ShareName, p => p.MapFrom(d => d.Share != null ? d.Share.Name : null));

            cfg.CreateMap<UserExam, UserExamInfo>()
                .ForMember(dto => dto.ExamName, e => e.MapFrom(a => a.Exam.Name))
                .ForMember(dto => dto.ExamUrlName, e => e.MapFrom(a => a.Exam.UrlName))
                .ForMember(dto => dto.StartDate, e => e.MapFrom(a => a.Start.ToString("dd.MM.yyyy")))
                .ForMember(dto => dto.Duration, e => e.MapFrom(a => a.End.HasValue ? (a.End.Value - a.Start).ToString(@"hh\:mm\:ss") : "00:00:00"))
                .ForMember(dto => dto.Score, e => e.MapFrom(a => a.Score ?? 0))
                .ForMember(dto => dto.CertificateNumber, e => e.MapFrom(a => a.Certificate.UniqueNumber));

            cfg.CreateMap<Certificate, UserCertificate>()
                .ForMember(c => c.ExamName, c => c.MapFrom(d => d.AccessibleItem.Name))
                .ForMember(c => c.UserName, c => c.MapFrom(d => d.User.UserName))
                .ForMember(c => c.Score, c => c.MapFrom(d => d.Exam.Score ?? 0))
                .ForMember(c => c.MaxScore, c => c.MapFrom(d => d.Exam.MaxScore))
                .ForMember(c => c.Date, c => c.MapFrom(d => d.Exam.Start.ToString("dd.MM.yyyy")))
                .ForMember(c => c.Number, c => c.MapFrom(d => d.UniqueNumber));
        }

        private void RegisterToEFEntitiesMappings(IMapperConfigurationExpression cfg)
        {

        }
    }
}
