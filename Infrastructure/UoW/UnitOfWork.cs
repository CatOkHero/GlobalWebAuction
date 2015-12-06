using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DomainModels.Bets;
using DomainModels.Categories;
using DomainModels.Guarantee;
using DomainModels.Lots;
using DomainModels.Photo;
using DomainModels.Shipping;
using DomainModels.Status;
using Infrastructure.Abstraction;
using Infrastructure.Repository;

namespace Infrastructure.UoW
{
    class UnitOfWork
    {
        //private readonly AuctionDb.AuctionDb _context = new AuctionDb.AuctionDb();
        //private bool _disposed;

        //private IRepository<StatusModel> _roleRepository;
        //private IRepository<ShippingModel> _wordRepostiory;
        //private IRepository<PhotoModel> _languageRepository;
        //private IRepository<LotModel> _groupRepository;
        //private IRepository<LotDetailsModel> _enrollmentRepository;
        //private IRepository<LotTypePriceModel> _courseRepository;
        //private IRepository<GuaranteeModel> _tagRepository;
        //private IRepository<CategoryModel> CategoryModels;
        //private IRepository<SubCategoryModel> SubCategoryModels;
        //private IRepository<BetModel> BetModels;

        //public IRepository<StatusModel> StatusModelRepository
        //{
        //    get
        //    {
        //        return _enrollmentRepository ?? (_enrollmentRepository = new BaseModelRepository<StatusModel>(_context));
        //    }
        //}
        //public IRepository<Group> GroupRepository
        //{
        //    get
        //    {
        //        return _groupRepository ?? (_groupRepository = new BaseModelRepository<Group>(_context));
        //    }
        //}
        //public IRepository<Role> RoleRepository
        //{
        //    get
        //    {
        //        return _roleRepository ?? (_roleRepository = new BaseModelRepository<Role>(_context));
        //    }
        //}
        //public IRepository<Word> WordRepository
        //{
        //    get
        //    {
        //        return _wordRepostiory ?? (_wordRepostiory = new BaseModelRepository<Word>(_context));
        //    }
        //}
        //public IRepository<Language> LanguageRepository
        //{
        //    get
        //    {
        //        return _languageRepository ?? (_languageRepository = new BaseModelRepository<Language>(_context));
        //    }
        //}
        //public IRepository<Course> CourseRepository
        //{
        //    get
        //    {
        //        return _courseRepository ?? (_courseRepository = new BaseModelRepository<Course>(_context));
        //    }
        //}
        //public IRepository<Tag> TagRepository
        //{
        //    get
        //    {
        //        return _tagRepository ?? (_tagRepository = new BaseModelRepository<Tag>(_context));
        //    }
        //}
        //public IWordTranslationRepository WordTranslationRepository
        //{
        //    get
        //    {
        //        return _wordTranslationRepository ??
        //               (_wordTranslationRepository = new WordTranslationRepository(_context));
        //    }
        //}
        //public IWordSuiteRepository WordSuiteRepository
        //{
        //    get
        //    {
        //        return _wordSuiteRepository ?? (_wordSuiteRepository = new WordSuiteRepository(_context));
        //    }
        //}
        //public IWordProgressRepository WordProgressRepository
        //{
        //    get
        //    {
        //        return _wordProgressRepository ?? (_wordProgressRepository = new WordProgressRepository(_context));
        //    }
        //}
        //public IIncomingUserRepository IncomingUserRepository
        //{
        //    get
        //    {
        //        return _incomingUserRepository ?? (_incomingUserRepository = new IncomingUserRepository(_context));
        //    }
        //}
        //public IUserRepository UserRepository
        //{
        //    get
        //    {
        //        return _userRepository ?? (_userRepository = new UserRepository(_context));
        //    }
        //}

        //public void Save()
        //{
        //    _context.SaveChanges();
        //}

        //protected virtual void Dispose(bool disposing)
        //{
        //    if (!_disposed)
        //    {
        //        if (disposing)
        //        {
        //            _context.Dispose();
        //        }
        //    }
        //    _disposed = true;
        //}

        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}
    }
}
