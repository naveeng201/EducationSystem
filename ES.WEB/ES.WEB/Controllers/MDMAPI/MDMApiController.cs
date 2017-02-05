using ES.DAL.repositories;
using ES.MODELS;
using ES.SERVICE;
using ES.WEB.Models;
using Microsoft.AspNet.Identity.Owin;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
//using System.Runtime.Serialization.;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Transactions;
using System.Web;
using System.Globalization;
using System.DirectoryServices.AccountManagement;
using System.Web.Security;
using Excel;
using System.Data;
using System.Net.Mail;
using ES.WEB.Services;


//using ES.SERVICE.repository;

namespace ES.WEB.Controllers
{
    [Authorize]
    public class MDMAPIController : ApiController
    {
        #region //Variable Declaration
        private readonly IActivityTypeSerivece activeTypeService;
        private readonly IAspNetUserService aspnetUserService;
        private readonly IAssetClassService assetClassService;
        private readonly IAssetLocationService assetLocationService;
        private readonly IAssetService assetService;
        private readonly IAssetSubClassService assetSubClassService;
        private readonly IAssetSupperService assetSupperService;
        private readonly ICityService cityService;
        private readonly ICompanyService companyService;
        private readonly IControlingAreaService controlingAreaService;
        private readonly ICostCenterCategoryService costCenterCategoryService;
        private readonly ICostCenterService costcenterService;
        private readonly ICountryService countryService;
        private readonly ICurrencyService currencyService;
        private readonly IDepartmentService departmentService;
        private readonly IDepreciationService depreciationService;
        private readonly IDistrictService districtService;
        private readonly IFiscalYearService fiscalYearService;
        private readonly IEmployeeService employeeService;
        private readonly IExchangeRateService exchagerateService;
        private readonly IExchangeRateHistoryService exchagerateHistoryService;
        private readonly IExchangeRateTransactionService exchagerateTransactionService;
        private readonly IGeneralLedgerService generalledgerService;
        private readonly IInternalOrderService internalOrderService;
        private readonly ILocalLanguageService localLanguageService;
        private readonly ILVACategoryService lvaCategoryService;
        private readonly IMaintenanceOrderService maintenanceOrderService;
        private readonly IMasterService masterService;
        private readonly IMetaTableService metaTableService;
        private readonly IMissionService missionService;
        private readonly IPlantService plantService;
        private readonly IProfitCenterAreaService profitCenterAreaService;
        private readonly IProfitCenterService profitCenterService;
        private readonly IProfitCenterTemplateService profitCenterTemplateService;
        private readonly IReceipientTypeService receipientTypeService;
        private readonly IRegionService regionService;
        private readonly IRegionStateService regionStateService;
        private readonly ISegmentService segmentService;
        private readonly IStandardHierarchyAreaService standardHierarchyAreaService;
        private readonly ISubRegionService subRegionService;
        private readonly ITaxService taxService;
        private readonly ITaxTypeService taxTypeService;
        private readonly ITaxJurisdictionService taxJurisdictionService;
        private readonly IUnitMeasurementService unitMeasurementService;
        private readonly IWorkFlowService workFlowService;
        private readonly IVendorService vendorService;
        private readonly IWorkFlowUserService workFlowUserService;
        private readonly IWorkFlowLevelService workFlowLevelService;
        private readonly IWorkFlowStatusService workFlowStatusService;
        private readonly IWorkFlowUserStatusService workFlowUserStatusService;
        private readonly IBankService bankService;
        private readonly IWHTTaxKeyService whtTaxKeyService;
        private readonly IWHTTaxLawService whtTaxLawService;
        private readonly IWHTTaxService whtTaxService;
        private readonly IWHTTaxTypeService whtTaxTypeService;
        /* Customer start */
        private readonly IAccountGroupService accountGroupService;
        private readonly IAccountingClerkService accountingClerkService;
        private readonly IAccountStatementService accountStatementService;
        private readonly ICashManagementGroupService cashManagementGroupService;
        private readonly ICustomerTransactionService customerTransactionService;
        private readonly ICustomerAccountService customerAccountService;
        private readonly IDunningAreaService dunningAreaService;
        private readonly IDunningBlockService dunningBlockService;
        private readonly IDunningClerkService dunningClerkService;
        private readonly IDunningProcedureService dunningProcedureService;
        private readonly IDunningRecipientService dunningRecipientService;
        private readonly IGroupKeyService groupKeyService;
        private readonly IHouseBankService houseBankService;
        private readonly IPaymentBlockService paymentBlockService;
        private readonly IPaymentMethodService paymentMethodService;
        private readonly IPaymentTermService paymentTermService;
        private readonly IReasonCodeConversionService reasonCodeConversionService;
        private readonly IRegionalStructureGroupingService regionalStructureGroupingService;
        private readonly ISelectionRuleService selectionRuleService;
        private readonly ISortKeyService sortKeyService;
        private readonly ITimeZoneService timeZoneService;
        private readonly ITitleService titleService;
        private readonly IToleranceGroupService toleranceGroupService;
        /* Customer End */
        private readonly IVendorTransactionService vendorTransactionService;
        private readonly IPaymentTransactionService paymentTransactionService;
        private readonly IStatisticalKeyFigureService statisticalKeyFigureService;
        private readonly IStatisticalKeyFigureUnitService statisticalKeyFigureUnitService;
        private readonly IHierarchyService hierarchyService;
        private readonly IWHTTaxforVendorService whtTaxforVendorService;
        private readonly ICustomerPaymentTransactionService customerPaymentTransactionService;
        private readonly ICustomerWithholdingTaxService customerWithholdingTaxService;
        private readonly ICustomerPaymentMethodService customerPaymentMethodService;
        #endregion

        #region //Public Constructor
        public MDMAPIController
        (
            IActivityTypeSerivece _activetypeService,
            IAspNetUserService _aspnetUserService,
            IAssetClassService _assetClassService,
            IAssetLocationService _assetLocationService,
            IAssetService _assetService,
            IAssetSubClassService _assetSubClassService,
            IAssetSupperService _assetSupperService,
            IBankService _bankService,
            ICityService _cityService,
            ICompanyService _companyService,
            IControlingAreaService _controlingAreaService,
            ICostCenterCategoryService _costCenterCategoryService,
            ICostCenterService _costcenterService,
            ICountryService _countryService,
            ICurrencyService _currencyService,
            IDepartmentService _departmentService,
            IDepreciationService _depreciationService,
            IDistrictService _districtService,
            IEmployeeService _employeeService,
            IExchangeRateService _exchagerateService,
            IExchangeRateHistoryService _exchagerateHistoryService,
            IExchangeRateTransactionService _exchangeRateTransactionService,
            IFiscalYearService _fiscalYearService,
            IGeneralLedgerService _generlledgerService,
            IInternalOrderService _internalOrderService,
            ILocalLanguageService _localLanguageService,
            ILVACategoryService _lvaCategoryService,
            IMaintenanceOrderService _maintenanceOrderService,
            IMasterService _masterService,
            IMetaTableService _metaTableService,
            IMissionService _missionService,
            IPlantService _plantService,
            IProfitCenterAreaService _profitCenterAreaService,
            IProfitCenterService _profitcenterService,
            IProfitCenterTemplateService _profitCenterTemplateService,
            IReceipientTypeService _receipientTypeService,
            IRegionService _regionService,
            IRegionStateService _regionStateService,
            ISegmentService _segmentService,
            IStandardHierarchyAreaService _standardHierarchyAreaService,
            ISubRegionService _subRegionService,
            ITaxService _taxService,
            ITaxTypeService _taxTypeService,
            ITaxJurisdictionService _taxJurisdictionService,
            IUnitMeasurementService _unitMeasurementService,
            IWorkFlowLevelService _workFlowLevelService,
            IWorkFlowStatusService _workFlowStatusService,
            IWorkFlowService _workFlowService,
            //IStatusService _statusService
            //ILevelService _levelService,
            //IMasterService _masterService                               
            IVendorService _vendorService,
            IWorkFlowUserService _workFlowUserService,
            IWorkFlowUserStatusService _workFlowUserStatusService,
            IWHTTaxKeyService _whtTaxKeyService,
            IWHTTaxLawService _whtTaxLawService,
            IWHTTaxService _whtTaxService,
            IWHTTaxTypeService _whtTaxTypeService,
            /* Customer start */
            IAccountGroupService _accountGroupService,
            IAccountingClerkService _accountingClerkService,
            IAccountStatementService _accountStatementService,
            ICashManagementGroupService _cashManagementGroupService,
            ICustomerTransactionService _customerTransactionService,
            ICustomerAccountService _customerAccountService,
            IDunningAreaService _dunningAreaService,
            IDunningBlockService _dunningBlockService,
            IDunningClerkService _dunningClerkService,
            IDunningProcedureService _dunningProcedureService,
            IDunningRecipientService _dunningRecipientService,
            IGroupKeyService _groupKeyService,
            IHouseBankService _houseBankService,
            IPaymentBlockService _paymentBlockService,
            IPaymentMethodService _paymentMethodService,
            IPaymentTermService _paymentTermService,
            IReasonCodeConversionService _reasonCodeConversionService,
            IRegionalStructureGroupingService _regionalStructureGroupingService,
            ISelectionRuleService _selectionRuleService,
            ISortKeyService _sortKeyService,
            ITimeZoneService _timeZoneService,
            ITitleService _titleService,
            IToleranceGroupService _toleranceGroupService,
            /* Customer End */
            IVendorTransactionService _vendorTransactionService,
            IPaymentTransactionService _paymentTransactionService,
            IStatisticalKeyFigureService _statisticalKeyFigureService,
            IStatisticalKeyFigureUnitService _statisticalKeyFigureUnitService,
            IHierarchyService _hierarchyService,
            IWHTTaxforVendorService _whtTaxforVendorService,
            ICustomerPaymentTransactionService _customerPaymentTransactionService,
            ICustomerWithholdingTaxService _customerWithholdingTaxService,
            ICustomerPaymentMethodService _customerPaymentMethodService

            )
        {
            this.activeTypeService = _activetypeService;
            this.aspnetUserService = _aspnetUserService;
            this.assetClassService = _assetClassService;
            this.assetLocationService = _assetLocationService;
            this.assetService = _assetService;
            this.assetSubClassService = _assetSubClassService;
            this.assetSupperService = _assetSupperService;
            this.bankService = _bankService;
            this.cityService = _cityService;
            this.companyService = _companyService;
            this.controlingAreaService = _controlingAreaService;
            this.costCenterCategoryService = _costCenterCategoryService;
            this.costcenterService = _costcenterService;
            this.countryService = _countryService;
            this.currencyService = _currencyService;
            this.departmentService = _departmentService;
            this.depreciationService = _depreciationService;
            this.districtService = _districtService;
            this.employeeService = _employeeService;
            this.exchagerateService = _exchagerateService;
            this.exchagerateHistoryService = _exchagerateHistoryService;
            this.exchagerateTransactionService = _exchangeRateTransactionService;
            this.fiscalYearService = _fiscalYearService;
            this.generalledgerService = _generlledgerService;
            this.internalOrderService = _internalOrderService;
            this.localLanguageService = _localLanguageService;
            this.lvaCategoryService = _lvaCategoryService;
            this.maintenanceOrderService = _maintenanceOrderService;
            this.masterService = _masterService;
            this.metaTableService = _metaTableService;
            this.missionService = _missionService;
            this.plantService = _plantService;
            this.profitCenterAreaService = _profitCenterAreaService;
            this.profitCenterService = _profitcenterService;
            this.profitCenterTemplateService = _profitCenterTemplateService;
            this.receipientTypeService = _receipientTypeService;
            this.regionService = _regionService;
            this.regionStateService = _regionStateService;
            this.segmentService = _segmentService;
            this.standardHierarchyAreaService = _standardHierarchyAreaService;
            this.subRegionService = _subRegionService;
            this.taxService = _taxService;
            this.taxTypeService = _taxTypeService;
            this.taxJurisdictionService = _taxJurisdictionService;
            this.unitMeasurementService = _unitMeasurementService;
            //this.statusService = _statusService;
            //this.levelService = _levelService;
            this.workFlowLevelService = _workFlowLevelService;
            this.workFlowStatusService = _workFlowStatusService;
            this.workFlowService = _workFlowService;
            //this.masterService = _masterService;
            this.vendorService = _vendorService;
            this.workFlowUserService = _workFlowUserService;
            this.workFlowUserStatusService = _workFlowUserStatusService;
            this.whtTaxKeyService = _whtTaxKeyService;
            this.whtTaxLawService = _whtTaxLawService;
            this.whtTaxService = _whtTaxService;
            this.whtTaxTypeService = _whtTaxTypeService;
            /* Customer start */
            this.accountGroupService = _accountGroupService;
            this.accountingClerkService = _accountingClerkService;
            this.accountStatementService = _accountStatementService;
            this.cashManagementGroupService = _cashManagementGroupService;
            this.customerTransactionService = _customerTransactionService;
            this.customerAccountService = _customerAccountService;
            this.dunningAreaService = _dunningAreaService;
            this.dunningBlockService = _dunningBlockService;
            this.dunningClerkService = _dunningClerkService;
            this.dunningProcedureService = _dunningProcedureService;
            this.dunningRecipientService = _dunningRecipientService;
            this.groupKeyService = _groupKeyService;
            this.houseBankService = _houseBankService;
            this.paymentBlockService = _paymentBlockService;
            this.paymentMethodService = _paymentMethodService;
            this.paymentTermService = _paymentTermService;
            this.reasonCodeConversionService = _reasonCodeConversionService;
            this.regionalStructureGroupingService = _regionalStructureGroupingService;
            this.selectionRuleService = _selectionRuleService;
            this.sortKeyService = _sortKeyService;
            this.timeZoneService = _timeZoneService;
            this.titleService = _titleService;
            this.toleranceGroupService = _toleranceGroupService;
            /* Customer End */
            this.vendorTransactionService = _vendorTransactionService;
            this.paymentTransactionService = _paymentTransactionService;
            this.statisticalKeyFigureService = _statisticalKeyFigureService;
            this.statisticalKeyFigureUnitService = _statisticalKeyFigureUnitService;
            this.hierarchyService = _hierarchyService;
            this.whtTaxforVendorService = _whtTaxforVendorService;
            this.customerPaymentTransactionService = _customerPaymentTransactionService;
            this.customerWithholdingTaxService = _customerWithholdingTaxService;
            this.customerPaymentMethodService = _customerPaymentMethodService;
        }
        #endregion

        #region//LoginAndLogoff
        [AllowAnonymous]
        [HttpPost]
        [ResponseType(typeof(LoginViewModel))]
        public IHttpActionResult Login(LoginViewModel loginModel)
        {

            SignInStatus result = SignInStatus.Failure;
            if (!ModelState.IsValid)
            {
                return Ok("Invalid Username/Password");
            }
            try
            {
                if (System.Configuration.ConfigurationManager.AppSettings["IsADAuthenticationActive"].ToString().ToUpper() != "1")
                {
                    result = Helper.SignInManager.PasswordSignIn(loginModel.UserName, loginModel.Password, loginModel.RememberMe, shouldLockout: false);
                    switch (result)
                    {
                        case SignInStatus.Success:
                            {
                                return Ok("Success");
                            }
                    }

                    return Ok("Failure");
                }
                else if (System.Configuration.ConfigurationManager.AppSettings["IsADAuthenticationActive"].ToString().ToUpper() == "1")
                {

                    using (PrincipalContext context = new PrincipalContext(ContextType.Domain, ConfigurationManager.AppSettings["DomainName"].ToString()))
                    {
                        if (context.ValidateCredentials(loginModel.UserName, loginModel.Password))
                        {
                            var user = Helper.UserManager.Users.ToList().FirstOrDefault(u => u.UserName == loginModel.UserName);

                            if (user != null)
                            {
                                Helper.SignInManager.SignIn(user, true, false);
                                return Ok("Success");
                            }
                            else
                                return Ok("You are eligible to access MDM application, Please contact with Admin");
                        }
                        else
                        {
                            return Ok("Failure");
                        }
                    }

                }
                else
                    return Ok("Failure");


                // return Ok("Success");

            }
            catch (Exception ex)
            {
                return Ok("Failure");

            }



        }
        public IHttpActionResult LogOff()
        {
            //FormsAuthentication.SignOut();
            HttpContext.Current.GetOwinContext().Authentication.SignOut();
            Redirect("Acount/Login");
            return Ok("HR");
        }

        [HttpPost]
        public async Task<HttpResponseMessage> ChangePassword(ManageUserViewModel model)
        {
            HttpResponseMessage response = null;
            var result = Helper.UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
            if (result.Result.Succeeded)
            {
                response = Request.CreateResponse(HttpStatusCode.OK, "Success");
            }
            return response;
        }




        #endregion

        #region//Region
        [HttpGet]
        public HttpResponseMessage GetRegion()
        {
            HttpResponseMessage response = null;
            try
            {
                //var regionList = regionService.GetAll().ToList();
                var workflow = workFlowStatusService.GetAll().Where(WF => WF.MasterId == "RG").Select(WF => new { WF.Requestnumber }).ToList();
                var regionList = regionService.GetAll().Where(RG => !workflow.Any(WS => WS.Requestnumber == RG.RequestNumber) && RG.CreatedBy == User.Identity.Name).OrderByDescending(m => m.Id).ToList();
                regionList.ForEach(c => c.Level = true);
                response = Request.CreateResponse(HttpStatusCode.OK, regionList);
                return response;

            }
            catch (Exception Ex)
            {
                return null;
            }
        }
        // POST api/StudentInfoAPI
        [HttpPost]
        [Route("api/MDMAPI/AddRegion/{IsSubmit}")]
        public HttpResponseMessage AddRegion(Region region, bool IsSubmit)
        {
            HttpResponseMessage response = null;
            try
            {
                if (!ModelState.IsValid)
                {
                    response = Request.CreateResponse(HttpStatusCode.InternalServerError, BadRequest(ModelState));
                    return response;
                }
                if (region.Id == 0)
                {
                    region.CreatedBy = User.Identity.Name;
                    region.CreatedDate = DateTime.Now;
                    region.RequestNumber = "RG" + Helper.GetRandomNumber();

                    region.IsDelete = false;
                    int i = regionService.Insert(region);
                }
                else
                {
                    region.ModifiedBy = User.Identity.Name;
                    region.ModifiedDate = DateTime.Now;
                    regionService.Update(region);
                }
                if (IsSubmit)
                {
                    if (string.IsNullOrWhiteSpace(region.Comments))
                    {
                        region.Comments = "Created By region";
                    }
                    CreateWorkflow("RG", region.RequestNumber, region.Comments);
                }
                response = Request.CreateResponse(HttpStatusCode.OK, "Successfully Inserted");
                return response;
            }
            catch (Exception Ex)
            {
                return null;
            }
        }

        [HttpGet]
        public HttpResponseMessage LoadRegion(int Id)
        {

            HttpResponseMessage response = null;
            RegionData regionData = new RegionData();
            if (Id == 0)
            {
                regionData.objRegion = new Region();
            }
            else
            {
                regionData.objRegion = null;
            }
            regionData.MetaTableList = metaTableService.GetAll().Where(f => f.MasterCode == "RG").ToList();
            // profitCenter.MetaTableList = metaTableService.GetAll().Where(f => f.MasterCode == "PC").ToList();
            //regionData.objRegion = regionService.GetAll().Where(Rg => Rg.Id == Id).ToList();
            regionData.IsWorflowAssigned = workFlowService.GetID("RG") > 0 ? true : false;

            response = Request.CreateResponse(HttpStatusCode.OK, regionData);
            return response;
        }

        [HttpGet]
        [Route("api/MDMAPI/GetRegionByRequestNumber/{requestNumber}")]
        public HttpResponseMessage GetRegionByRequestNumber(string requestNumber)
        {
            HttpResponseMessage response = null;
            try
            {
                var allowSubmit = workFlowService.IsAllowtoSubmit("RG", User.Identity.GetUserId(), requestNumber);
                var region = regionService.GetAll().Where(CC => CC.RequestNumber == requestNumber).ToList();
                region.ForEach(p => p.IsAllowtoSubmit = allowSubmit);
                if (IsLastLevelApproval("RG", requestNumber))
                {
                    region.ForEach(c => c.Level = true);
                }
                else
                {
                    region.ForEach(c => c.Level = false);
                }
                response = Request.CreateResponse(HttpStatusCode.OK, region);
                return response;
            }
            catch (Exception Ex)
            {
                return null;
            }
        }

        [HttpPost]
        public HttpResponseMessage ApproveRegion(ApproveInfo approveInfo)
        {
            //if (!string.IsNullOrWhiteSpace(approveInfo.finalLevedModifiedDataRegion.From))
            //{
            //    approveInfo.finalLevedModifiedDataRegion.FromDate = DateTime.Parse(approveInfo.finalLevedModifiedDataRegion.From, new CultureInfo("en-CA"));
            //}
            //if (!string.IsNullOrWhiteSpace(approveInfo.finalLevedModifiedDataRegion.To))
            //{
            //    approveInfo.finalLevedModifiedDataRegion.ToDate = DateTime.Parse(approveInfo.finalLevedModifiedDataRegion.To, new CultureInfo("en-CA"));
            //}
            HttpResponseMessage response = null;
            using (var trans = new TransactionScope())
            {
                if (approveInfo.finalLevedModifiedDataRegion != null)
                {
                    var region = regionService.SingleOrDefault(approveInfo.finalLevedModifiedDataRegion.Id);
                    if (!String.IsNullOrWhiteSpace(approveInfo.finalLevedModifiedDataRegion.Description))
                        region.Description = approveInfo.finalLevedModifiedDataRegion.Description;
                    if (!String.IsNullOrWhiteSpace(approveInfo.finalLevedModifiedDataRegion.Code))
                        region.Code = approveInfo.finalLevedModifiedDataRegion.Code;
                    region.ModifiedBy = User.Identity.Name;
                    region.ModifiedDate = DateTime.Now;
                    regionService.Update(region);
                }
                ApproveWorkflow("RG", approveInfo.requestNumber, approveInfo.status, approveInfo.comments);

                #region "Code to insert Region Comments"

                var _region = regionService.GetAll().Where(A => A.RequestNumber == approveInfo.requestNumber).SingleOrDefault();
                _region.Comments = approveInfo.comments;
                regionService.Update(_region);
                #endregion
                response = Request.CreateResponse(HttpStatusCode.OK, "Success");
                trans.Complete();
            }


            return response;
        }

        [HttpGet]
        [Route("api/MDMAPI/isExistingRegionCode/{regioncode}/{id}")]
        public bool isExistingRegionCode(string regioncode, int id)
        {
            var regionList = new List<Region>();
            if (id == 0)
            {
                regionList = regionService.GetAll().Where(r => r.Code == regioncode).ToList();
            }
            else
            {
                regionList = regionService.GetAll().Where(r => r.Code == regioncode && r.Id != id).ToList();
            }
            //var regionCode = regionService.GetAll().Where(r => r.Code == regioncode).SingleOrDefault();
            bool isexists = false;
            if (regionList.Count > 0)
            {
                isexists = true;
            }
            return isexists;
        }
        #endregion

        #region  Asset
        [Authorize(Roles = "User")]
        [HttpGet]
        public HttpResponseMessage getAsset()
        {
            HttpResponseMessage response = null;
            try
            {
                var workflow = workFlowStatusService.GetAll().Where(WF => WF.MasterId == "AS").Select(WF => new { WF.Requestnumber }).ToList();
                var assetData = assetService.GetAll().Where(CC => !workflow.Any(WS => WS.Requestnumber == CC.RequestNumber) && CC.CreatedBy == User.Identity.Name).OrderByDescending(m => m.Id).ToList();
                assetData.ForEach(c => c.Level = true);
                response = Request.CreateResponse(HttpStatusCode.OK, assetData);
                return response;

            }
            catch (Exception Ex)
            {
                return null;
            }
        }

        [HttpPost]
        [Route("api/MDMAPI/AddAsset/{IsSubmit}")]
        public HttpResponseMessage AddAsset(Asset asset, bool IsSubmit)
        {
            HttpResponseMessage response = null;
            try
            {
                ModelState.Remove("asset.lastInventoryDate");
                ModelState.Remove("asset.assetCapitalizationDate");
                ModelState.Remove("asset.originalAcquisitionDate");
                ModelState.Remove("asset.depreciationStartDate");
                if (!IsSubmit)
                {
                    ModelState.Remove("asset.AditionalWorkflowId");
                }
                if (!ModelState.IsValid)
                {
                    response = Request.CreateResponse(HttpStatusCode.InternalServerError, BadRequest(ModelState));
                    return response;
                }


                if (!string.IsNullOrWhiteSpace(asset.LastDate))
                {
                    asset.LastInventoryDate = DateTime.Parse(asset.LastDate, new CultureInfo("en-CA"));
                }

                if (!string.IsNullOrWhiteSpace(asset.AssetDate))
                {
                    asset.AssetCapitalizationDate = DateTime.Parse(asset.AssetDate, new CultureInfo("en-CA"));
                }
                if (!string.IsNullOrWhiteSpace(asset.OriginalDate))
                {
                    asset.OriginalAcquisitionDate = DateTime.Parse(asset.OriginalDate, new CultureInfo("en-CA"));
                }
                if (!string.IsNullOrWhiteSpace(asset.DepreciationDate))
                {
                    asset.DepreciationStartDate = DateTime.Parse(asset.DepreciationDate, new CultureInfo("en-CA"));
                }

                asset.IsDelete = false;
                if (asset.Id == 0)
                {
                    asset.RequestNumber = "AS" + Helper.GetRandomNumber();
                    asset.CreatedBy = User.Identity.Name;
                    asset.CreatedOn = DateTime.Now;
                    assetService.Insert(asset);
                }
                else
                {
                    asset.ModifiedBy = User.Identity.Name;
                    asset.ModifiedOn = DateTime.Now;
                    assetService.Update(asset);
                }
                if (IsSubmit)
                {
                    CreateWorkflow("AS", asset.RequestNumber, asset.Comments, asset.AditionalWorkflowId);
                }
                response = Request.CreateResponse(HttpStatusCode.OK, "Successfully Inserted");
                return response;
            }
            catch (Exception Ex)
            {
                return null;
            }
        }

        [HttpGet]
        public HttpResponseMessage LoadAssetDropdownList(int Id)
        {
            try
            {
                AssetDetails assetdetails = new AssetDetails();
                HttpResponseMessage response = null;
                assetdetails = assetService.Getdrodowndata(Id);
                //if (Id == 0)
                //{
                //    assetdetails.objAsset = new Asset();
                //}
                //else
                //    assetdetails.objAsset = null;
                assetdetails.IsWorflowAssigned = workFlowService.GetID("AS") > 0 ? true : false;
                response = Request.CreateResponse(HttpStatusCode.OK, assetdetails);
                return response;
                #region Commented removing code from WebAPI to Repository
                //assetdetails.MetaTableList = metaTableService.GetAll().Where(f => f.MasterCode == "AS").ToList();
                //assetdetails.activetypeList = activeTypeService.GetAll().Where(W => W.IsDelete == null ? true : W.IsDelete == false ? true : false).Select(F => new DropdownColumn() { id = F.Id, name = F.Code + "|" + F.Name }).ToList<DropdownColumn>();
                //assetdetails.companyList = companyService.GetAll().Where(W => W.IsDelete == null ? true : W.IsDelete == false ? true : false).Select(F => new DropdownColumn() { id = F.Id, name = F.CompanyCode + " | " + F.CompanyDescription }).ToList<DropdownColumn>(); ;

                //assetdetails.assetClassList = assetClassService.GetAll().Where(w => w.IsDelete == null ? true : w.IsDelete == false ? true : false).Select(F => new DropdownColumn() { id = F.Id, name = F.Code + "|" + F.Name }).ToList<DropdownColumn>();
                //assetdetails.baseUnitMeasurementList = unitMeasurementService.GetAll().Where(w => w.IsDelete == null ? true : w.IsDelete == false ? true : false).Select(F => new DropdownColumn() { id = F.Id, name = F.Code + "|" + F.Name }).ToList<DropdownColumn>();
                //assetdetails.businessAreaList = regionService.GetAll().Where(w => w.IsDelete == null ? true : w.IsDelete == false ? true : false).Select(F => new DropdownColumn() { id = F.Id, name = F.Code + "|" + F.Description }).ToList<DropdownColumn>();
                //assetdetails.plantList = plantService.GetAll().Where(w => w.IsDelete == null ? true : w.IsDelete == false ? true : false).Select(F => new DropdownColumn() { id = F.Id, name = F.Code + "|" + F.Description }).ToList<DropdownColumn>();
                //assetdetails.assetLocationList = assetLocationService.GetAll().Where(w => w.IsDelete == null ? true : w.IsDelete == false ? true : false).Select(F => new DropdownColumn() { id = F.Id, name = F.Code + "|" + F.Name }).ToList<DropdownColumn>();
                //assetdetails.roomList = cityService.GetAll().Where(w => w.IsDelete == null ? true : w.IsDelete == false ? true : false).Select(F => new DropdownColumn() { id = F.Id, name = F.Code + "|" + F.Description }).ToList<DropdownColumn>();
                //assetdetails.personalNumList = employeeService.GetAll().Where(w => w.IsDelete == null ? true : w.IsDelete == false ? true : false).Select(F => new DropdownColumn() { id = F.Id, name = F.Code + "|" + F.FirstName }).ToList<DropdownColumn>();
                //assetdetails.maintenanceOrderList = maintenanceOrderService.GetAll().Where(w => w.IsDelete == null ? true : w.IsDelete == false ? true : false).Select(F => new DropdownColumn() { id = F.Id, name = F.Code + "|" + F.Name }).ToList<DropdownColumn>();
                //assetdetails.assetSubClassList = assetSubClassService.GetAll().Where(w => w.IsDelete == null ? true : w.IsDelete == false ? true : false).Select(F => new DropdownColumn() { id = F.Id, name = F.Code + "|" + F.Name }).ToList<DropdownColumn>();
                //assetdetails.lvaCategoryList = lvaCategoryService.GetAll().Where(w => w.IsDelete == null ? true : w.IsDelete == false ? true : false).Select(F => new DropdownColumn() { id = F.Id, name = F.Code + "|" + F.Name }).ToList<DropdownColumn>();
                //assetdetails.countryList = countryService.GetAll().Where(w => w.IsDelete == null ? true : w.IsDelete == false ? true : false).Select(F => new DropdownColumn() { id = F.Id, name = F.Code + "|" + F.Name }).ToList<DropdownColumn>();
                //assetdetails.departmentList = departmentService.GetAll().Where(w => w.IsDelete == null ? true : w.IsDelete == false ? true : false).Select(F => new DropdownColumn() { id = F.Id, name = F.Code + "|" + F.Name }).ToList<DropdownColumn>();
                //assetdetails.internalOrderList = internalOrderService.GetAll().Select(x => new DropdownColumn() { id = x.Id, name = x.Description }).ToList<DropdownColumn>(); ;
                //assetdetails.depreciationList = depreciationService.GetAll().Where(w => w.IsDelete == null ? true : w.IsDelete == false ? true : false).Select(F => new DropdownColumn() { id = F.Id, name = F.Code + "|" + F.UserName }).ToList<DropdownColumn>();
                //assetdetails.costCenterList = costcenterService.GetAll().Where(w => w.IsDelete == null ? true : w.IsDelete == false ? true : false).Select(F => new DropdownColumn() { id = F.Id, parrentId = F.BusinessAreaId, name = F.Code + "|" + F.Name }).ToList<DropdownColumn>();
                //assetdetails.assetSuperNumList = assetSupperService.GetAll().Where(w => w.IsDelete == null ? true : w.IsDelete == false ? true : false).Select(F => new DropdownColumn() { id = F.Id, name = F.Code + "|" + F.Name }).ToList<DropdownColumn>();
                //assetdetails.vendorAccList = vendorService.GetAll().Where(w => w.IsDelete == null ? true : w.IsDelete == false ? true : false).Select(F => new DropdownColumn() { id = F.Id, name = F.Code + "|" + F.Name }).ToList<DropdownColumn>();
                //assetdetails.IsWorflowAssigned = workFlowService.GetID("AS") > 0 ? true : false;
                ////response = Request.CreateResponse(HttpStatusCode.OK, assetdetails);
                //return response;
                #endregion
            }
            catch (Exception Ex)
            {
                return null;
            }
        }

        [HttpGet]
        [Route("api/MDMAPI/GetASByRequestNumber/{requestNumber}")]
        public HttpResponseMessage GetASByRequestNumber(string requestNumber)
        {
            HttpResponseMessage response = null;
            try
            {
                var allowSubmit = workFlowService.IsAllowtoSubmit("AS", User.Identity.GetUserId(), requestNumber);
                var asset = assetService.GetAll().Where(CC => CC.RequestNumber == requestNumber).ToList();

                var workflow = workFlowStatusService.GetAll().Where(W => W.Requestnumber == requestNumber && W.MasterId == "AS" && W.IsDelete == false).ToList();
                if (workflow.Count > 0)
                {
                    asset.ForEach(c => c.AditionalWorkflowId = (int)workflow[0].WorkFlowId);
                }
                asset.ForEach(a => a.IsAllowtoSubmit = allowSubmit);
                if (IsLastLevelApproval("AS", requestNumber))
                {
                    asset.ForEach(c => c.Level = false);
                }
                else
                {
                    asset.ForEach(c => c.Level = true);
                }
                response = Request.CreateResponse(HttpStatusCode.OK, asset);
                return response;
            }
            catch (Exception Ex)
            {
                return null;
            }
        }

        [HttpPost]
        public HttpResponseMessage ApproveAsset(ApproveInfo approveInfo)
        {
            HttpResponseMessage response = null;
            ApproveWorkflow("AS", approveInfo.requestNumber, approveInfo.status, approveInfo.comments);
            var assert = assetService.GetAll().Where(A => A.RequestNumber == approveInfo.requestNumber).SingleOrDefault();
            assert.Comments = approveInfo.comments;
            assetService.Update(assert);

            response = Request.CreateResponse(HttpStatusCode.OK, "Success");
            return response;
        }

        [HttpPost]
        public HttpResponseMessage AssetCopyRecord(Asset asset)
        {
            HttpResponseMessage response = null;
            try
            {
                if (!ModelState.IsValid)
                {
                    response = Request.CreateResponse(HttpStatusCode.InternalServerError, BadRequest(ModelState));
                    return response;
                }
                // var ass = assetClassService.SingleOrDefault(AssetId);
                asset.CreatedBy = User.Identity.Name;
                asset.CreatedOn = DateTime.Now;
                asset.ModifiedBy = null;
                asset.ModifiedOn = null;
                asset.Id = 0;
                asset.RequestNumber = "AS" + Helper.GetRandomNumber();
                assetService.Insert(asset);
                response = Request.CreateResponse(HttpStatusCode.OK, "Successfully Copy");
                return response;



            }
            catch (Exception Ex)
            {
                return null;
            }
        }
        #endregion

        #region//CostCenter
        [HttpGet]
        public HttpResponseMessage LoadDashBoard()
        {
            HttpResponseMessage response = null;
            try
            {
                var dashBoard = workFlowStatusService.GetDashBoard(User.Identity.GetUserId());
                response = Request.CreateResponse(HttpStatusCode.OK, dashBoard);
                return response;

            }
            catch (Exception Ex)
            {
                return null;
            }
        }
        [HttpGet]
        [Route("api/MDMAPI/LoadHistory/{requestNumber}")]
        public HttpResponseMessage LoadHistory(string requestNumber)
        {
            HttpResponseMessage response = null;
            try
            {
                var dashBoard = workFlowStatusService.LoadHistory(User.Identity.GetUserId(), requestNumber);
                response = Request.CreateResponse(HttpStatusCode.OK, dashBoard);
                return response;

            }
            catch (Exception Ex)
            {
                return null;
            }
        }
        [HttpGet]
        public HttpResponseMessage LoadHistoryHeader()
        {
            HttpResponseMessage response = null;
            try
            {
                var dashBoard = workFlowStatusService.LoadHistoryHeader(User.Identity.GetUserId());
                response = Request.CreateResponse(HttpStatusCode.OK, dashBoard);
                return response;

            }
            catch (Exception Ex)
            {
                return null;
            }
        }
        [HttpGet]
        public HttpResponseMessage GetCostCenter()
        {
            try
            {
                HttpResponseMessage response = null;
                response = Request.CreateResponse(HttpStatusCode.OK, costcenterService.GetDraftData(Helper.GetMasterCode(Masters.CostCenter), User.Identity.Name));
                return response;
            }
            catch (Exception Ex)
            {
                return null;
            }
        }
        private bool IsLastLevelApproval(string MasterCode, string requestNumber)
        {
            try
            {
                return costcenterService.IsLastLevelApproval(workFlowStatusService.GetID(MasterCode, requestNumber), MasterCode, requestNumber);
            }
            catch (Exception Ex)
            {
                return false;
            }
        }
        [HttpGet]
        [Route("api/MDMAPI/GetCCByRequestNumber/{requestNumber}")]
        public HttpResponseMessage GetCCByRequestNumber(string requestNumber)
        {
            HttpResponseMessage response = null;
            try
            {
                var allowSubmit = workFlowService.IsAllowtoSubmit(Helper.GetMasterCode(Masters.CostCenter), User.Identity.GetUserId(), requestNumber);
                var costcenter = costcenterService.GetCCByRequestNumber(requestNumber, allowSubmit, IsLastLevelApproval(Helper.GetMasterCode(Masters.CostCenter), requestNumber));
                response = Request.CreateResponse(HttpStatusCode.OK, costcenter);
                return response;
            }
            catch (Exception Ex)
            {
                return null;
            }
        }
        [HttpPost]
        [Route("api/MDMAPI/AddCostCenter/{IsSubmit}")]
        public HttpResponseMessage AddCostCenter(CostCenter costcenter, bool IsSubmit)
        {

            HttpResponseMessage response = null;
            try
            {
                if (!string.IsNullOrWhiteSpace(costcenter.From))
                {
                    costcenter.ValidFrom = DateTime.Parse(costcenter.From, new CultureInfo("en-CA"));
                }
                if (!string.IsNullOrWhiteSpace(costcenter.To))
                {
                    costcenter.ValidTo = DateTime.Parse(costcenter.To, new CultureInfo("en-CA"));
                }
                if (!IsSubmit)
                {
                    ModelState.Remove("costcenter.AditionalWorkflowId");
                }
                ModelState.Remove("costcenter.validFrom");
                ModelState.Remove("costcenter.validTo");
                if (!ModelState.IsValid)
                {
                    response = Request.CreateResponse(HttpStatusCode.InternalServerError, BadRequest(ModelState));
                    return response;
                }
                costcenter.IsDelete = false;
                using (var t = new TransactionScope())
                {
                    if (costcenter.Id == 0)
                    {
                        // This Area Need to Insert in BULK Insert Method                    
                        costcenter.CreatedBy = User.Identity.Name;
                        costcenter.CreatedDate = DateTime.Now;
                        costcenter.RequestNumber = Helper.GetMasterCode(Masters.CostCenter) + Helper.GetRandomNumber();
                        costcenterService.Insert(costcenter);

                    }
                    else
                    {
                        costcenter.ModifiedBy = User.Identity.Name;
                        costcenter.ModifiedDate = DateTime.Now;
                        costcenterService.Update(costcenter);
                    }
                    if (IsSubmit)
                    {
                        CreateWorkflow(Helper.GetMasterCode(Masters.CostCenter), costcenter.RequestNumber, costcenter.Comments, costcenter.AditionalWorkflowId);
                    }
                    t.Complete();
                }
                response = Request.CreateResponse(HttpStatusCode.OK, "Successfully Inserted");
                return response;
            }
            catch (Exception Ex)
            {
                return null;
            }
        }
        [HttpGet]
        public HttpResponseMessage LoadCostCenterDropdownList()
        {
            try
            {
                HttpResponseMessage response = null;
                var costCenter = costcenterService.getDropdownData(Helper.GetMasterCode(Masters.CostCenter));
                costCenter.IsWorflowAssigned = workFlowService.GetID(Helper.GetMasterCode(Masters.CostCenter)) > 0 ? true : false;
                response = Request.CreateResponse(HttpStatusCode.OK, costCenter);
                return response;
            }
            catch (Exception Ex)
            {
                return null;
            }
        }
        #region code to know existing costcentercode
        [HttpGet]
        [Route("api/MDMAPI/IsExistingCode/{costcentercode}")]
        public bool IsExistingCode(string costcentercode, string master)
        {

            var costcenterdata = costcenterService.GetAll().Where(cc => cc.Code == costcentercode).SingleOrDefault();
            bool isexists = false;
            if (costcenterdata != null)
            {
                isexists = true;
            }
            return isexists;

        }
        #endregion
        #endregion

        #region//Helper Functions
        private void SendMail(WorkFlowStatu objWorkFlowStatus)
        {
            var emailList = workFlowUserStatusService.GetWorkUserStatusByStatusId(objWorkFlowStatus.Id);
            string filePath = HttpContext.Current.Request.PhysicalApplicationPath + @"\\Template\\NewRequestor.html";
            bool sentStatus = false;
            string subject = String.Empty;
            List<Email> emailToList = null;
            Email email = new Email();
            MailAddressCollection mailAddressToCollection = new MailAddressCollection();
            MailAddressCollection mailAddressCcCollection = new MailAddressCollection();
            if (objWorkFlowStatus.StatusID == 4 || objWorkFlowStatus.StatusID == 3)
            {

                var em = emailList.Where(el => el.LastModified == objWorkFlowStatus.ModifiedBy && (el.StatusId == 2 || el.StatusId == 3)).SingleOrDefault();

                if (em == null) { return; }
                if (em.StatusId == 2)
                {
                    subject = "Request - Approved";
                    filePath = HttpContext.Current.Request.PhysicalApplicationPath + @"\\Template\\RequestCompleted.html";
                }
                else if (em.StatusId == 3)
                {
                    subject = "Request - Rejected";
                    filePath = HttpContext.Current.Request.PhysicalApplicationPath + @"\\Template\\NewRequestRejected.html";
                }
                email.RequestNo = em.RequestNo;
                email.MasterName = em.MasterName;
                email.levelName = em.levelName;
                email.StatusName = em.StatusName;
                email.comments = em.comments;
                mailAddressToCollection.Add(em.RequestorEmail);
                foreach (var emt in emailList)
                {
                    mailAddressCcCollection.Add(emt.To);
                }
            }
            else
            {
                subject = "Awaiting Approver approval for New Request";
                emailToList = emailList.Where(e => e.StatusId == 1).ToList();
                foreach (var em in emailToList)
                {
                    mailAddressToCollection.Add(em.To);
                    email.RequestNo = em.RequestNo;
                    email.MasterName = em.MasterName;
                    email.levelName = em.levelName;
                    email.StatusName = "Pending Approval";
                    email.comments = em.comments == null ? String.Empty : em.comments;
                }
                if (emailToList.Count > 0)
                {
                    foreach (var em in emailList)
                    {
                        MailAddress ma = new MailAddress(em.Cc);
                        if (!mailAddressCcCollection.Contains(ma))
                        {
                            mailAddressCcCollection.Add(ma);
                        }
                        if (em.StatusId == 6)
                        {
                            ma = new MailAddress(em.To);
                            if (!mailAddressCcCollection.Contains(ma))
                            {
                                mailAddressCcCollection.Add(ma);
                            }
                        }
                    }
                }
            }

            if (mailAddressToCollection.Count > 0 && mailAddressCcCollection.Count > 0)
            {
                string MessageBody = Helper.ReplaceInFile(filePath, "@ApproverName", "@ReferenceNo", "@MasterName", "@levelName", "@Status_Name", "@Comments", "Approver", email.RequestNo, email.MasterName, email.levelName, email.StatusName, email.comments);

                sentStatus = Mailing.sendEmailWithCredentials(mailAddressToCollection, "", subject, mailAddressCcCollection, "", MessageBody, "", "");
            }
            if (sentStatus)
            {
                var wfus = workFlowUserStatusService.GetAll().Where(A => A.WorkFlowStatusId == objWorkFlowStatus.Id && A.StatusId == 1).ToList();
                foreach (var wfus1 in wfus)
                {
                    WorkFlowUserStatu wf = wfus1;
                    wf.StatusId = 5;
                    wf.IsMailSent = true;
                    workFlowUserStatusService.Update(wf);
                }
                if (objWorkFlowStatus.StatusID == 4 || objWorkFlowStatus.StatusID == 3)
                {
                    objWorkFlowStatus.IsMailSent = true;
                    workFlowStatusService.Update(objWorkFlowStatus);
                }
            }
        }
        private void CreateWorkflow(string MasterCode, string requestnumber, string comments = "", int additionalWorkflowId = 0)
        {

            int workflowId = additionalWorkflowId > 0 ? additionalWorkflowId : workFlowService.GetID(MasterCode);
            DateTime currentDate = DateTime.Now;
            var workflowLevel = workFlowLevelService.GetAll().Where(WL => WL.WorkflowId == workflowId && WL.LevelId == (int)StatusId.Initiated).ToList();
            WorkFlowStatu WS = new WorkFlowStatu();
            WS.MasterId = MasterCode;
            WS.StatusID = (int)StatusId.ApprovalPending;
            WS.Requestnumber = requestnumber;
            WS.WorkFlowId = workflowId;
            WS.CreatedBy = User.Identity.GetUserId();
            WS.CreatedDate = currentDate;
            WS.LatestComments = comments;
            WS.IsDelete = false;
            WS.IsMailSent = false;
            workFlowStatusService.Insert(WS);
            for (int i = 0; i < workflowLevel.Count; i++)
            {
                var user = workFlowUserService.GetUserId(workflowLevel[i].Id).ToList();
                for (int j = 0; j < user.Count; j++)
                {
                    WorkFlowUserStatu WF = new WorkFlowUserStatu();
                    WF.WorkFlowStatusId = WS.Id;
                    WF.LevelId = workflowLevel[i].LevelId;
                    WF.UserId = user[j].UserId;
                    WF.StatusId = (int)StatusId.Initiated;
                    WF.IsMailSent = false;
                    //WF.comments = comments;
                    WF.CreatedBy = User.Identity.GetUserId();
                    WF.CreatedDate = currentDate;
                    WF.IsDelete = false;
                    workFlowUserStatusService.Insert(WF);
                }
            }
            SendMail(WS);
        }
        public void ApproveWorkflow(string MasterCode, string requestnumber, bool Status, string Comments)
        {
            int workflowId = workFlowStatusService.GetID(MasterCode, requestnumber); //workFlowService.GetCurrentWorkflow(MasterCode, User.Identity.GetUserId());
            //foreach (var workflow in workflowList)
            //{
            var workflowLevel = workFlowLevelService.GetAll().Where(WL => WL.WorkflowId == workflowId).ToList();
            var workflowStatus = workFlowStatusService.GetAll().Where(WS => (WS.StatusID == (int)StatusId.ApprovalPending || WS.StatusID == (int)StatusId.Approved) && WS.WorkFlowId == workflowId && WS.MasterId == MasterCode && WS.Requestnumber == requestnumber).FirstOrDefault();
            var workflowuserStatus = workFlowUserStatusService.GetAll().Where(WF => WF.WorkFlowStatusId == workflowStatus.Id && WF.StatusId == (int)StatusId.ApprovalPending).ToList();
            var MaxLevel = workflowLevel[workflowLevel.Count - 1].LevelId;
            int statusId = (int)StatusId.Initiated;
            //if (MaxLevel == workflowuserStatus[0].LevelId && Status)
            //    statusId = (int)StatusId.Completed;
            //else 
            if (Status)
                statusId = (int)StatusId.Approved;
            else
                statusId = (int)StatusId.Rejected; ;
            //if (statusId == (int)StatusId.Completed || statusId == (int)StatusId.Approved)
            if (MaxLevel == workflowuserStatus[0].LevelId && Status == true)
                workflowStatus.StatusID = (int)StatusId.Completed;
            else
                workflowStatus.StatusID = statusId;
            //workflowStatus.LatestComments = Comments;
            workflowStatus.ModifiedBy = User.Identity.GetUserId();
            workflowStatus.ModifiedDate = DateTime.Now;
            workFlowStatusService.Update(workflowStatus);
            foreach (var workflowUser in workflowuserStatus)
            {
                if (workflowUser.UserId == User.Identity.GetUserId())
                {
                    workflowUser.StatusId = statusId;
                    workflowUser.comments = Comments;
                    workflowUser.ModifiedBy = User.Identity.GetUserId();
                    workflowUser.ModifiedDate = DateTime.Now;
                }
                else
                {
                    workflowUser.StatusId = (int)StatusId.AlreadyApproved;
                    workflowUser.ModifiedBy = User.Identity.GetUserId();
                    workflowUser.ModifiedDate = DateTime.Now;
                }
                workFlowUserStatusService.Update(workflowUser);
            }
            if (MaxLevel != workflowuserStatus[0].LevelId && statusId != (int)StatusId.Rejected)
            {
                var user = workFlowUserService.GetUserId(workflowLevel[workflowuserStatus[0].LevelId].Id).ToList();
                for (int j = 0; j < user.Count; j++)
                {
                    WorkFlowUserStatu WF = new WorkFlowUserStatu();
                    WF.WorkFlowStatusId = workflowStatus.Id;
                    WF.LevelId = workflowuserStatus[0].LevelId + 1;
                    WF.UserId = user[j].UserId;
                    WF.StatusId = 1;
                    WF.IsMailSent = false;
                    //WF.comments = Comments;
                    WF.CreatedBy = User.Identity.GetUserId();
                    WF.CreatedDate = DateTime.Now;
                    WF.IsDelete = false;
                    workFlowUserStatusService.Insert(WF);
                }
            }
            // }
            SendMail(workflowStatus);
        }
        [HttpPost]
        public HttpResponseMessage ApproveCostCenter(ApproveInfo approveInfo)
        {

            if (!string.IsNullOrWhiteSpace(approveInfo.finalLevedModifiedData.From))
            {
                approveInfo.finalLevedModifiedData.FromDate = DateTime.Parse(approveInfo.finalLevedModifiedData.From, new CultureInfo("en-CA"));
            }
            if (!string.IsNullOrWhiteSpace(approveInfo.finalLevedModifiedData.To))
            {
                approveInfo.finalLevedModifiedData.ToDate = DateTime.Parse(approveInfo.finalLevedModifiedData.To, new CultureInfo("en-CA"));
            }
            HttpResponseMessage response = null;
            using (var tes = new TransactionScope())
            {
                if (approveInfo.finalLevedModifiedData != null)
                {
                    var costCenter = costcenterService.SingleOrDefault(approveInfo.finalLevedModifiedData.Id);
                    if (!String.IsNullOrWhiteSpace(approveInfo.finalLevedModifiedData.Name))
                        costCenter.Name = approveInfo.finalLevedModifiedData.Name;
                    if (!String.IsNullOrWhiteSpace(approveInfo.finalLevedModifiedData.Code))
                        costCenter.Code = approveInfo.finalLevedModifiedData.Code;
                    if (!String.IsNullOrWhiteSpace(Convert.ToString(approveInfo.finalLevedModifiedData.FromDate)))
                        costCenter.ValidFrom = approveInfo.finalLevedModifiedData.FromDate;
                    if (!String.IsNullOrWhiteSpace(Convert.ToString(approveInfo.finalLevedModifiedData.ToDate)))
                        costCenter.ValidTo = approveInfo.finalLevedModifiedData.ToDate;

                    costCenter.Comments = approveInfo.comments;
                    costcenterService.Update(costCenter);
                }
                ApproveWorkflow("CC", approveInfo.requestNumber, approveInfo.status, approveInfo.comments);

                var costcenterReq = costcenterService.GetAll().Where(A => A.RequestNumber == approveInfo.requestNumber).SingleOrDefault();
                costcenterReq.Comments = approveInfo.comments;
                costcenterService.Update(costcenterReq);

                response = Request.CreateResponse(HttpStatusCode.OK, "Success");
                tes.Complete();
            }

            return response;
        }

        [HttpPost]
        public HttpResponseMessage GetHistory(ApprovalHistoryRequest request)
        {
            HttpResponseMessage response = null;
            var workflowHistory = workFlowStatusService.GetApproverDetails(request.MasterCode, request.RequestName);
            response = Request.CreateResponse(HttpStatusCode.OK, workflowHistory);
            return response;
        }
        #endregion

        #region//ProfitCenter
        [HttpGet]

        public HttpResponseMessage LoadProfitCenterDropdowns(int Id)
        {

            HttpResponseMessage response = null;
            ProfitCenterData profitCenter = new ProfitCenterData();
            if (Id == 0)
            {
                profitCenter.objProfitCenter = new ProfitCenter();
                profitCenter.objProfitCenter.ValidFrom = System.DateTime.Now;
                profitCenter.objProfitCenter.ValidTo = System.DateTime.Now;
            }
            else
            {
                profitCenter.objProfitCenter = null;
            }
            profitCenter.MetaTableList = metaTableService.GetAll().Where(f => f.MasterCode == "PC").ToList();
            //profitCenter.cityList = cityService.GetAll().Where(W => W.IsDelete == null ? true : W.IsDelete == false ? true : false).Select(F => new DropdownColumn() { id = F.Id, name =F.Code+" | "+ F.Description }).ToList<DropdownColumn>();
            profitCenter.companyList = companyService.GetAll().Where(W => W.IsDelete == null ? true : W.IsDelete == false ? true : false).Select(F => new DropdownColumn() { id = F.Id, name = F.CompanyCode + " | " + F.CompanyDescription }).ToList<DropdownColumn>();
            profitCenter.controlingAreaList = controlingAreaService.GetAll().Where(W => W.IsDelete == null ? true : W.IsDelete == false ? true : false).Select(F => new DropdownColumn() { id = F.Id, name = F.Code + " | " + F.Name }).ToList<DropdownColumn>();
            profitCenter.countryList = countryService.GetAll().Where(W => W.IsDelete == null ? true : W.IsDelete == false ? true : false).Select(F => new DropdownColumn() { id = F.Id, name = F.Code + " | " + F.Name }).ToList<DropdownColumn>();
            profitCenter.currencyList = currencyService.GetAll().Where(W => W.IsDelete == null ? true : W.IsDelete == false ? true : false).Select(F => new DropdownColumn() { id = F.Id, name = F.Code + " | " + F.Description }).ToList<DropdownColumn>();
            // profitCenter.departmentList = departmentService.GetAll().Where(w => w.IsDelete == null ? true : w.IsDelete == true ? true : false).Select(F => new DropdownColumn() { id = F.Id, name = F.Code + " | " + F.Name }).ToList<DropdownColumn>();
            // profitCenter.districtList = districtService.GetAll().Select(F => new DropdownColumn() { id = F.Id, name = F.Area }).ToList<DropdownColumn>();
            try
            {
                profitCenter.employeeList = employeeService.GetAll().Where(W => (W.IsDelete == null ? true : W.IsDelete == false ? true : false) && W.UserId != null).Select(F => new DropdownColumn() { id = F.Id, name = F.Code + " | " + F.FirstName }).ToList<DropdownColumn>();
            }
            catch (Exception ex)
            {
                var test = 0;
            }
            profitCenter.localLanguageList = localLanguageService.GetAll().Where(W => W.IsDelete == null ? true : W.IsDelete == false ? true : false).Select(F => new DropdownColumn() { id = F.Id, name = F.Code + " | " + F.Description }).ToList<DropdownColumn>();
            profitCenter.profitCenterAreaList = profitCenterAreaService.GetAll().Where(W => W.IsDelete == null ? true : W.IsDelete == false ? true : false).Select(F => new DropdownColumn() { id = F.Id, name = F.Code + " | " + F.Name }).ToList<DropdownColumn>();
            profitCenter.profitCenterTemplateList = profitCenterTemplateService.GetAll().Where(W => W.IsDelete == null ? true : W.IsDelete == false ? true : false).Select(F => new DropdownColumn() { id = F.Id, name = F.Code + " | " + F.Name }).ToList<DropdownColumn>();
            profitCenter.regionStateList = regionStateService.GetAll().Where(W => W.IsDelete == null ? true : W.IsDelete == false ? true : false).Select(F => new DropdownColumn() { id = F.Id, name = F.StateCode + " | " + F.StateName, parrentId = F.CountryId }).ToList<DropdownColumn>();
            profitCenter.taxJurisdictionList = taxJurisdictionService.GetAll().Where(W => W.IsDelete == null ? true : W.IsDelete == false ? true : false).Select(F => new DropdownColumn() { id = F.Id, name = F.Code + " | " + F.Name }).ToList<DropdownColumn>();
            profitCenter.IsWorflowAssigned = workFlowService.GetID("PC") > 0 ? true : false;
            profitCenter.segmentList = segmentService.GetAll().Where(W => W.IsDelete == null ? true : W.IsDelete == false ? true : false).Select(F => new DropdownColumn() { id = F.Id, name = F.Code + " | " + F.Name }).ToList<DropdownColumn>();
            var additionalWorkflowList = workFlowService.GetAll().Where(W => W.IsDelete == false && W.IsAdditionalWorkFlow == true && W.MasterCode == "PC").Select(F => new DropdownColumn() { id = F.Id, name = F.Name, parrentId = F.CompanyId }).ToList<DropdownColumn>();
            var baseflow = workFlowService.GetAll().Where(W => W.IsDelete == false && W.IsAdditionalWorkFlow == false && W.MasterCode == "PC").Select(F => new DropdownColumn() { id = F.Id, name = "-- None --", parrentId = F.CompanyId }).ToList<DropdownColumn>();
            profitCenter.additionalWorkflow = baseflow.Union(additionalWorkflowList).ToList();
            response = Request.CreateResponse(HttpStatusCode.OK, profitCenter);
            return response;
        }

        [HttpGet]
        public HttpResponseMessage GetProfitCenter()
        {
            HttpResponseMessage response = null;
            try
            {
                var workflow = workFlowStatusService.GetAll().Where(WF => WF.MasterId == "PC").Select(WF => new { WF.Requestnumber }).ToList();
                var profitcenter = profitCenterService.GetAll().Where(CC => !workflow.Any(WS => WS.Requestnumber == CC.RequestNumber) && CC.CreatedBy == User.Identity.Name).OrderByDescending(m => m.Id).ToList();
                profitcenter.ForEach(c => c.Level = true);
                //if (IsLastLevelApproval("PC"))
                //{
                //    profitcenter.ForEach(c => c.Level = false);
                //}
                //else
                //{
                //    profitcenter.ForEach(c => c.Level = true);
                //}
                response = Request.CreateResponse(HttpStatusCode.OK, profitcenter);
                return response;

            }
            catch (Exception Ex)
            {
                return null;
            }
        }

        [HttpPost]
        [Route("api/MDMAPI/AddProfitCenter/{IsSubmit}")]
        public HttpResponseMessage AddProfitCenter(ProfitCenter profitCenter, bool IsSubmit)
        {
            HttpResponseMessage response = null;
            try
            {
                if (!string.IsNullOrWhiteSpace(profitCenter.From))
                {
                    profitCenter.ValidFrom = DateTime.Parse(profitCenter.From, new CultureInfo("en-CA"));
                }
                if (!string.IsNullOrWhiteSpace(profitCenter.To))
                {
                    profitCenter.ValidTo = DateTime.Parse(profitCenter.To, new CultureInfo("en-CA"));
                }
                if (!IsSubmit)
                {
                    ModelState.Remove("profitCenter.AditionalWorkflowId");
                }
                ModelState.Remove("profitCenter.validFrom");
                ModelState.Remove("profitCenter.validTo");
                if (!ModelState.IsValid)
                {
                    response = Request.CreateResponse(HttpStatusCode.InternalServerError, BadRequest(ModelState));
                    return response;
                }
                profitCenter.IsDelete = false;
                if (profitCenter.Id == 0)
                {
                    profitCenter.RequestNumber = "PC" + Helper.GetRandomNumber();
                    profitCenter.CreatedBy = User.Identity.Name;
                    profitCenter.CreatedDate = DateTime.Now;
                    profitCenterService.Insert(profitCenter);
                }
                else
                {
                    profitCenter.ModifiedBy = User.Identity.Name;
                    profitCenter.ModifiedDate = DateTime.Now;
                    profitCenterService.Update(profitCenter);
                }
                if (IsSubmit)
                {
                    if (string.IsNullOrWhiteSpace(profitCenter.Comments))
                    {
                        profitCenter.Comments = "Created By ProfitCenter";
                    }
                    CreateWorkflow("PC", profitCenter.RequestNumber, profitCenter.Comments, profitCenter.AditionalWorkflowId);
                }
                response = Request.CreateResponse(HttpStatusCode.OK, "Successfully Inserted");
                return response;
            }
            catch (Exception Ex)
            {
                return null;
            }
        }

        [HttpGet]
        [Route("api/MDMAPI/GetPCByRequestNumber/{requestNumber}")]
        public HttpResponseMessage GetPCByRequestNumber(string requestNumber)
        {
            HttpResponseMessage response = null;
            try
            {
                var allowSubmit = workFlowService.IsAllowtoSubmit("PC", User.Identity.GetUserId(), requestNumber);
                var profitCenter = profitCenterService.GetAll().Where(CC => CC.RequestNumber == requestNumber).ToList();
                var workflow = workFlowStatusService.GetAll().Where(W => W.Requestnumber == requestNumber && W.MasterId == "PC" && W.IsDelete == false).ToList();
                if (workflow.Count > 0)
                {
                    profitCenter.ForEach(c => c.AditionalWorkflowId = (int)workflow[0].WorkFlowId);
                }
                profitCenter.ForEach(p => p.IsAllowtoSubmit = allowSubmit);
                if (IsLastLevelApproval("PC", requestNumber))
                {
                    profitCenter.ForEach(c => c.Level = false);
                }
                else
                {
                    profitCenter.ForEach(c => c.Level = true);
                }
                response = Request.CreateResponse(HttpStatusCode.OK, profitCenter);
                return response;
            }
            catch (Exception Ex)
            {
                return null;
            }
        }

        [HttpPost]
        public HttpResponseMessage ApproveProfitCenter(ApproveInfo approveInfo)
        {
            if (!string.IsNullOrWhiteSpace(approveInfo.finalLevedModifiedData.From))
            {
                approveInfo.finalLevedModifiedData.FromDate = DateTime.Parse(approveInfo.finalLevedModifiedData.From, new CultureInfo("en-CA"));
            }
            if (!string.IsNullOrWhiteSpace(approveInfo.finalLevedModifiedData.To))
            {
                approveInfo.finalLevedModifiedData.ToDate = DateTime.Parse(approveInfo.finalLevedModifiedData.To, new CultureInfo("en-CA"));
            }
            HttpResponseMessage response = null;
            using (var trans = new TransactionScope())
            {
                if (approveInfo.finalLevedModifiedData != null)
                {
                    var profitCenter = profitCenterService.SingleOrDefault(approveInfo.finalLevedModifiedData.Id);
                    if (!String.IsNullOrWhiteSpace(approveInfo.finalLevedModifiedData.Name))
                        profitCenter.ProfitCenterName = approveInfo.finalLevedModifiedData.Name;
                    if (!String.IsNullOrWhiteSpace(approveInfo.finalLevedModifiedData.Code))
                        profitCenter.ProfitCenterCode = approveInfo.finalLevedModifiedData.Code;
                    if ((!String.IsNullOrWhiteSpace(Convert.ToString(approveInfo.finalLevedModifiedData.FromDate)) && approveInfo.finalLevedModifiedData.FromDate >= Convert.ToDateTime("1/1/2000"))
)
                        profitCenter.ValidFrom = approveInfo.finalLevedModifiedData.FromDate;
                    if (!String.IsNullOrWhiteSpace(Convert.ToString(approveInfo.finalLevedModifiedData.ToDate)) && approveInfo.finalLevedModifiedData.ToDate >= Convert.ToDateTime("1/1/2000"))
                        profitCenter.ValidTo = approveInfo.finalLevedModifiedData.ToDate;
                    profitCenterService.Update(profitCenter);
                }
                ApproveWorkflow("PC", approveInfo.requestNumber, approveInfo.status, approveInfo.comments);

                #region Code to insert Prifit center Comments
                var profit = profitCenterService.GetAll().Where(A => A.RequestNumber == approveInfo.requestNumber).SingleOrDefault();
                profit.Comments = approveInfo.comments;
                profitCenterService.Update(profit);
                #endregion
                response = Request.CreateResponse(HttpStatusCode.OK, "Success");
                trans.Complete();
            }


            return response;
        }

        #region code to know existing Profitcenter
        [HttpGet]
        [Route("api/MDMAPI/IsExistingProfitCode/{profitcentercode}")]
        public bool IsExistingProfitCode(string profitcentercode)
        {

            var profitcenterdata = profitCenterService.GetAll().Where(cc => cc.ProfitCenterCode == profitcentercode).SingleOrDefault();
            bool isexists = false;
            if (profitcenterdata != null)
            {
                isexists = true;
            }
            return isexists;

        }
        #endregion
        #endregion

        #region//Bank
        [HttpGet]

        public HttpResponseMessage LoadBankDropdowns(int Id)
        {

            HttpResponseMessage response = null;
            BankData Bank = new BankData();
            if (Id == 0)
            {
                Bank.objBank = new Bank();
            }
            else
            {
                Bank.objBank = null;
            }
            Bank.metaTableList = metaTableService.GetAll().Where(f => f.MasterCode == "BK").ToList();
            Bank.companyList = companyService.GetAll().Where(W => W.IsDelete == null ? true : W.IsDelete == false ? true : false).Select(F => new DropdownColumn() { id = F.Id, name = F.CompanyCode + " | " + F.CompanyDescription }).ToList<DropdownColumn>();
            Bank.currencyList = currencyService.GetAll().Where(W => W.IsDelete == null ? true : W.IsDelete == false ? true : false).Select(F => new DropdownColumn() { id = F.Id, name = F.Code + " | " + F.Description }).ToList<DropdownColumn>();
            Bank.regionList = regionStateService.GetAll().Where(W => W.IsDelete == null ? true : W.IsDelete == false ? true : false).Select(F => new DropdownColumn() { id = F.Id, name = F.StateCode + " | " + F.StateName, parrentId = F.CountryId }).ToList<DropdownColumn>();
            Bank.countryList = countryService.GetAll().Where(w => w.IsDelete == null ? true : w.IsDelete == false ? true : false).Select(F => new DropdownColumn() { id = F.Id, name = F.Code + "|" + F.Name }).ToList<DropdownColumn>();
            Bank.IsWorflowAssigned = workFlowService.GetID("BK") > 0 ? true : false;

            response = Request.CreateResponse(HttpStatusCode.OK, Bank);
            return response;
        }

        [HttpGet]
        public HttpResponseMessage GetBank()
        {
            HttpResponseMessage response = null;
            try
            {
                var workflow = workFlowStatusService.GetAll().Where(WF => WF.MasterId == "BK").Select(WF => new { WF.Requestnumber }).ToList();
                var Bank = bankService.GetAll().Where(BK => !workflow.Any(WS => WS.Requestnumber == BK.RequestNumber) && BK.CreatedBy == User.Identity.Name && !string.IsNullOrEmpty(BK.RequestNumber)).OrderByDescending(m => m.Id).ToList();
                Bank.ForEach(c => c.Level = true);
                response = Request.CreateResponse(HttpStatusCode.OK, Bank);
                return response;

            }
            catch (Exception Ex)
            {
                return null;
            }
        }

        [HttpPost]
        [Route("api/MDMAPI/AddBank/{IsSubmit}")]
        public HttpResponseMessage AddBank(Bank Bank, bool IsSubmit)
        {
            HttpResponseMessage response = null;
            try
            {

                if (!ModelState.IsValid)
                {
                    response = Request.CreateResponse(HttpStatusCode.InternalServerError, BadRequest(ModelState));
                    return response;
                }
                if (Bank.Id == 0)
                {
                    Bank.RequestNumber = "BK" + Helper.GetRandomNumber();
                    Bank.CreatedBy = User.Identity.Name;
                    Bank.CreatedDate = DateTime.Now;
                    bankService.Insert(Bank);
                }
                else
                {
                    Bank.ModifiedBy = User.Identity.Name;
                    Bank.ModifiedDate = DateTime.Now;
                    bankService.Update(Bank);
                }
                if (IsSubmit)
                {
                    if (string.IsNullOrWhiteSpace(Bank.Comments))
                    {
                        Bank.Comments = "Created By Bank";
                    }
                    CreateWorkflow("BK", Bank.RequestNumber, Bank.Comments);
                }
                response = Request.CreateResponse(HttpStatusCode.OK, "Successfully Inserted");
                return response;
            }
            catch (Exception Ex)
            {
                return null;
            }
        }

        [HttpGet]
        [Route("api/MDMAPI/GetBKByRequestNumber/{requestNumber}")]
        public HttpResponseMessage GetBKByRequestNumber(string requestNumber)
        {
            HttpResponseMessage response = null;
            try
            {
                var allowSubmit = workFlowService.IsAllowtoSubmit("BK", User.Identity.GetUserId(), requestNumber);
                var Bank = bankService.GetAll().Where(CC => CC.RequestNumber == requestNumber).ToList();
                Bank.ForEach(p => p.IsAllowtoSubmit = allowSubmit);
                if (IsLastLevelApproval("BK", requestNumber))
                {
                    Bank.ForEach(c => c.Level = true);
                }
                else
                {
                    Bank.ForEach(c => c.Level = false);
                }
                response = Request.CreateResponse(HttpStatusCode.OK, Bank);
                return response;
            }
            catch (Exception Ex)
            {
                return null;
            }
        }

        [HttpPost]
        public HttpResponseMessage ApproveBank(ApproveInfo approveInfo)
        {
            HttpResponseMessage response = null;
            using (var trans = new TransactionScope())
            {
                ApproveWorkflow("BK", approveInfo.requestNumber, approveInfo.status, approveInfo.comments);
                bankService.Update(approveInfo.BankData);
                response = Request.CreateResponse(HttpStatusCode.OK, "Success");
                trans.Complete();
            }
            return response;
        }


        #endregion

        #region//Company
        [HttpGet]

        public HttpResponseMessage LoadCompanyDropdowns(int Id)
        {

            HttpResponseMessage response = null;
            CompanyData Company = new CompanyData();
            if (Id == 0)
            {
                Company.objCompany = new Company();
            }
            else
            {
                Company.objCompany = null;
            }
            Company.metaTableList = metaTableService.GetAll().Where(f => f.MasterCode == "CO").ToList();
            Company.countryList = countryService.GetAll().Where(W => W.IsDelete == null ? true : W.IsDelete == false ? true : false).Select(F => new DropdownColumn() { id = F.Id, name = F.Code + " | " + F.Name }).ToList<DropdownColumn>();
            Company.currencyList = currencyService.GetAll().Where(W => W.IsDelete == null ? true : W.IsDelete == false ? true : false).Select(F => new DropdownColumn() { id = F.Id, name = F.Code + " | " + F.Description }).ToList<DropdownColumn>();
            Company.fiscalYearList = fiscalYearService.GetAll().Where(W => W.IsDelete == null ? true : W.IsDelete == false ? true : false).Select(F => new DropdownColumn() { id = F.Id, name = F.Code + " | " + F.Description }).ToList<DropdownColumn>();
            Company.regionList = regionStateService.GetAll().Where(W => W.IsDelete == null ? true : W.IsDelete == false ? true : false).Select(F => new DropdownColumn() { id = F.Id, name = F.StateCode + " | " + F.StateName, parrentId = F.CountryId }).ToList<DropdownColumn>();
            Company.subRegionList = subRegionService.GetAll().Where(W => W.IsDelete == null ? true : W.IsDelete == false ? true : false).Select(F => new DropdownColumn() { id = F.Id, name = F.SubRegionCode + " | " + F.SubRegionDescription, parrentId = F.RegionId }).ToList<DropdownColumn>();
            Company.businessRegionList = regionService.GetAll().Where(W => W.IsDelete == null ? true : W.IsDelete == false ? true : false).Select(F => new DropdownColumn() { id = F.Id, name = F.Code + " | " + F.Description }).ToList<DropdownColumn>();
            Company.localLanguageList = localLanguageService.GetAll().Where(W => W.IsDelete == null ? true : W.IsDelete == false ? true : false).Select(F => new DropdownColumn() { id = F.Id, name = F.Code + " | " + F.Description }).ToList<DropdownColumn>();
            Company.IsWorflowAssigned = workFlowService.GetID("CO") > 0 ? true : false;

            response = Request.CreateResponse(HttpStatusCode.OK, Company);
            return response;
        }

        [HttpGet]
        public HttpResponseMessage GetCompany()
        {
            HttpResponseMessage response = null;
            try
            {
                var workflow = workFlowStatusService.GetAll().Where(WF => WF.MasterId == "CO").Select(WF => new { WF.Requestnumber }).ToList();
                var Company = companyService.GetAll().Where(CO => !workflow.Any(WS => WS.Requestnumber == CO.RequestNumber) && CO.CreatedBy == User.Identity.Name && !string.IsNullOrEmpty(CO.RequestNumber)).OrderByDescending(m => m.Id).ToList();
                Company.ForEach(c => c.Level = true);
                response = Request.CreateResponse(HttpStatusCode.OK, Company);
                return response;

            }
            catch (Exception Ex)
            {
                return null;
            }
        }

        [HttpPost]
        [Route("api/MDMAPI/AddCompany/{IsSubmit}")]
        public HttpResponseMessage AddCompany(Company Company, bool IsSubmit)
        {
            HttpResponseMessage response = null;
            try
            {
                ModelState.Remove("Company.fiscalYearIFRSFromDate");
                ModelState.Remove("Company.fiscalYearIFRSToDate");
                ModelState.Remove("Company.fiscalYearLocalFromDate");
                ModelState.Remove("Company.fiscalYearLocalToDate");
                if (!ModelState.IsValid)
                {
                    response = Request.CreateResponse(HttpStatusCode.InternalServerError, BadRequest(ModelState));
                    return response;
                }
                if (!string.IsNullOrWhiteSpace(Company.strFiscalYearIFRSFromDate))
                {
                    Company.FiscalYearIFRSFromDate = DateTime.Parse(Company.strFiscalYearIFRSFromDate, new CultureInfo("en-CA"));
                }

                if (!string.IsNullOrWhiteSpace(Company.strFiscalYearIFRSToDate))
                {
                    Company.FiscalYearIFRSToDate = DateTime.Parse(Company.strFiscalYearIFRSToDate, new CultureInfo("en-CA"));
                }
                if (!string.IsNullOrWhiteSpace(Company.strFiscalYearLocalFromDate))
                {
                    Company.FiscalYearLocalFromDate = DateTime.Parse(Company.strFiscalYearLocalFromDate, new CultureInfo("en-CA"));
                }
                if (!string.IsNullOrWhiteSpace(Company.strFiscalYearLocalToDate))
                {
                    Company.FiscalYearLocalToDate = DateTime.Parse(Company.strFiscalYearLocalToDate, new CultureInfo("en-CA"));
                }
                if (Company.Id == 0)
                {
                    Company.RequestNumber = "CO" + Helper.GetRandomNumber();
                    Company.CreatedBy = User.Identity.Name;
                    Company.CreatedDate = DateTime.Now;
                    companyService.Insert(Company);
                }
                else
                {
                    Company.ModifiedBy = User.Identity.Name;
                    Company.ModifiedDate = DateTime.Now;
                    companyService.Update(Company);
                }
                if (IsSubmit)
                {
                    if (string.IsNullOrWhiteSpace(Company.Comments))
                    {
                        Company.Comments = "Created By Company";
                    }
                    CreateWorkflow("CO", Company.RequestNumber, Company.Comments);
                }
                response = Request.CreateResponse(HttpStatusCode.OK, "Successfully Inserted");
                return response;
            }
            catch (Exception Ex)
            {
                return null;
            }
        }

        [HttpGet]
        [Route("api/MDMAPI/GetCOByRequestNumber/{requestNumber}")]
        public HttpResponseMessage GetCOByRequestNumber(string requestNumber)
        {
            HttpResponseMessage response = null;
            try
            {
                var allowSubmit = workFlowService.IsAllowtoSubmit("CO", User.Identity.GetUserId(), requestNumber);
                var Company = companyService.GetAll().Where(CC => CC.RequestNumber == requestNumber).ToList();
                Company.ForEach(p => p.IsAllowtoSubmit = allowSubmit);
                if (IsLastLevelApproval("CO", requestNumber))
                {
                    Company.ForEach(c => c.Level = true);
                }
                else
                {
                    Company.ForEach(c => c.Level = false);
                }
                response = Request.CreateResponse(HttpStatusCode.OK, Company);
                return response;
            }
            catch (Exception Ex)
            {
                return null;
            }
        }

        [HttpPost]
        public HttpResponseMessage ApproveCompany(ApproveInfo approveInfo)
        {
            HttpResponseMessage response = null;

            ModelState.Remove("approveInfo.CompanyData.fiscalYearIFRSFromDate");
            ModelState.Remove("approveInfo.CompanyData.fiscalYearIFRSToDate");
            ModelState.Remove("approveInfo.CompanyData.fiscalYearLocalFromDate");
            ModelState.Remove("approveInfo.CompanyData.fiscalYearLocalToDate");
            if (!ModelState.IsValid)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, BadRequest(ModelState));
                return response;
            }
            if (!string.IsNullOrWhiteSpace(approveInfo.CompanyData.strFiscalYearIFRSFromDate))
            {
                approveInfo.CompanyData.FiscalYearIFRSFromDate = DateTime.Parse(approveInfo.CompanyData.strFiscalYearIFRSFromDate, new CultureInfo("en-CA"));
            }

            if (!string.IsNullOrWhiteSpace(approveInfo.CompanyData.strFiscalYearIFRSToDate))
            {
                approveInfo.CompanyData.FiscalYearIFRSToDate = DateTime.Parse(approveInfo.CompanyData.strFiscalYearIFRSToDate, new CultureInfo("en-CA"));
            }
            if (!string.IsNullOrWhiteSpace(approveInfo.CompanyData.strFiscalYearLocalFromDate))
            {
                approveInfo.CompanyData.FiscalYearLocalFromDate = DateTime.Parse(approveInfo.CompanyData.strFiscalYearLocalFromDate, new CultureInfo("en-CA"));
            }
            if (!string.IsNullOrWhiteSpace(approveInfo.CompanyData.strFiscalYearLocalToDate))
            {
                approveInfo.CompanyData.FiscalYearLocalToDate = DateTime.Parse(approveInfo.CompanyData.strFiscalYearLocalToDate, new CultureInfo("en-CA"));
            }

            using (var trans = new TransactionScope())
            {
                ApproveWorkflow("CO", approveInfo.requestNumber, approveInfo.status, approveInfo.comments);
                companyService.Update(approveInfo.CompanyData);
                response = Request.CreateResponse(HttpStatusCode.OK, "Success");
                trans.Complete();
            }
            return response;
        }

        #endregion

        #region MetaTable
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public HttpResponseMessage GetFieldsByMaster(string masterCode)
        {
            HttpResponseMessage response = null;
            try
            {
                var filedsList = metaTableService.GetAll().Where(f => f.MasterCode == masterCode).ToList();
                response = Request.CreateResponse(HttpStatusCode.OK, filedsList);
                return response;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public HttpResponseMessage UpdateMetaTable(MetaTable metaTable)
        {
            HttpResponseMessage response = null;
            try
            {
                metaTableService.Update(metaTable);
                response = Request.CreateResponse(HttpStatusCode.OK, "Successfully Inserted");
                return response;
            }
            catch (Exception Ex)
            {
                return null;
            }
        }
        #endregion

        #region WorkFlow
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public HttpResponseMessage GetWorkFlows()
        {
            HttpResponseMessage response = null;
            try
            {
                var workFlows = workFlowService.GetAllWorkFlow();

                response = Request.CreateResponse(HttpStatusCode.OK, workFlows);
                return response;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public HttpResponseMessage LoadWorkFlowDropdowns(int Id)
        {
            HttpResponseMessage response = null;
            WorkFlowDetails workFlow = new WorkFlowDetails();

            workFlow.companies = companyService.GetAll().Where(W => W.IsDelete == false ? true : false).Select(F => new DropdownColumn() { id = F.Id, name = F.CompanyCode + " | " + F.CompanyDescription }).ToList<DropdownColumn>();
            workFlow.masterList = masterService.GetActiveMasters().ToList();
            workFlow.usersList = aspnetUserService.GetAllUser().ToList();
            response = Request.CreateResponse(HttpStatusCode.OK, workFlow);
            return response;
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public HttpResponseMessage SaveWorkFlow(WorkFlow workFlow)
        {
            HttpResponseMessage response = null;
            try
            {

                if (workFlow.Id > 0)
                {
                    foreach (var level in workFlow.WorkFlowLevels)
                    {
                        level.WorkFlow = null;
                        foreach (var leveluser in level.WorkFlowUsers)
                        {
                            leveluser.WorkFlowLevel = null;
                            leveluser.WorflowLevelId = level.Id;
                            if (leveluser.Id == 0)
                            {
                                // workFlowUserService.Insert(leveluser);
                            }

                        }
                    }
                    // workFlowService.Update(workFlow);
                }
                else
                {

                    workFlowService.Insert(workFlow);

                }

                response = Request.CreateResponse(HttpStatusCode.OK, "Successfully Inserted");
                return response;
            }
            catch (Exception Ex)
            {
                return null;
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public HttpResponseMessage SetApprovalLevel(WorkFlow workFlow)
        {

            if (workFlow == null)
            {

                workFlow = new WorkFlow();
                workFlow.IsAdditionalWorkFlow = false;
            }

            WorkFlowLevel workFlowLevel = null;
            workFlow.WorkFlowLevels = new List<WorkFlowLevel>();

            HttpResponseMessage response = null;
            try
            {
                for (int i = 0 + 1; i <= workFlow.NoOfApprovals; i++)
                {

                    workFlowLevel = new WorkFlowLevel();

                    workFlowLevel.LevelId = i;
                    workFlowLevel.WorkFlowUsers = new List<WorkFlowUser>();
                    workFlow.WorkFlowLevels.Add(workFlowLevel);

                }

                response = Request.CreateResponse(HttpStatusCode.OK, workFlow);
                return response;
            }
            catch (Exception Ex)
            {
                return null;
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]

        public HttpResponseMessage CheckAdditionalWorkflowByMasterAndCompany(WorkFlow workFlow)
        {
            try
            {
                HttpResponseMessage response = null;
                int count = workFlowService.GetAll().Where(wf => wf.MasterCode == workFlow.MasterCode && wf.CompanyId == workFlow.CompanyId && wf.IsAdditionalWorkFlow == false).Count();


                response = Request.CreateResponse(HttpStatusCode.OK, count);
                return response;
            }
            catch (Exception Ex)
            {
                return null;
            }
        }

        #endregion

        #region Mission
        [HttpGet]
        public HttpResponseMessage GetMission()
        {
            HttpResponseMessage response = null;
            try
            {
                var workflow = workFlowStatusService.GetAll().Where(WF => WF.MasterId == "MS").Select(WF => new { WF.Requestnumber, WF.Id, WF.WorkFlowId }).ToList();
                var mission = missionService.GetAll().Where(MS => !workflow.Any(WS => WS.Requestnumber == MS.RequestNumber) && MS.CreatedBy == User.Identity.Name && !string.IsNullOrEmpty(MS.RequestNumber)).OrderByDescending(m => m.Id).ToList();
                mission.ForEach(c => c.Level = true);
                response = Request.CreateResponse(HttpStatusCode.OK, mission);

                return response;
            }
            catch (Exception Ex)
            {
                return null;
            }
        }
        [HttpGet]
        public HttpResponseMessage LoadMissionFieldAccess()
        {
            try
            {
                HttpResponseMessage response = null;
                MissionDetail mission = new MissionDetail();
                mission.objMission = new Mission();
                mission.metaTableList = metaTableService.GetAll().Where(f => f.MasterCode == "MS").ToList();
                mission.IsWorflowAssigned = workFlowService.GetID("MS") > 0 ? true : false;
                response = Request.CreateResponse(HttpStatusCode.OK, mission);
                return response;
            }
            catch (Exception Ex)
            {
                return null;
            }
        }
        [HttpPost]
        [Route("api/MDMAPI/AddMission/{IsSubmit}")]
        public HttpResponseMessage AddMission(Mission mission, bool IsSubmit)
        {

            HttpResponseMessage response = null;
            try
            {
                if (!ModelState.IsValid)
                {
                    response = Request.CreateResponse(HttpStatusCode.InternalServerError, BadRequest(ModelState));
                    return response;
                }
                using (var t = new TransactionScope())
                {
                    if (mission.Id == 0)
                    {
                        mission.CreatedBy = User.Identity.Name;
                        mission.CreatedDate = DateTime.Now;
                        mission.RequestNumber = "MS" + Helper.GetRandomNumber();
                        missionService.Insert(mission);

                    }
                    else
                    {
                        mission.ModifiedBy = User.Identity.Name;
                        mission.ModifiedDate = DateTime.Now;
                        missionService.Update(mission);
                    }
                    if (IsSubmit)
                    {
                        CreateWorkflow("MS", mission.RequestNumber, mission.Comments);
                    }
                    t.Complete();
                }
                response = Request.CreateResponse(HttpStatusCode.OK, "Successfully Inserted");
                return response;
            }
            catch (Exception Ex)
            {
                return null;
            }
        }
        [HttpPost]
        public HttpResponseMessage ApproveMission(ApproveInfo approveInfo)
        {
            HttpResponseMessage response = null;
            using (var tes = new TransactionScope())
            {
                if (approveInfo.finalLevedModifiedData != null)
                {
                    var mission = missionService.SingleOrDefault(approveInfo.finalLevedModifiedData.Id);
                    if (!String.IsNullOrWhiteSpace(approveInfo.finalLevedModifiedData.Name))
                        mission.Description = approveInfo.finalLevedModifiedData.Name;
                    if (!String.IsNullOrWhiteSpace(approveInfo.finalLevedModifiedData.Code))
                        mission.Code = approveInfo.finalLevedModifiedData.Code;

                    missionService.Update(mission);
                }

                ApproveWorkflow("MS", approveInfo.requestNumber, approveInfo.status, approveInfo.comments);
                var missionReq = missionService.GetAll().Where(A => A.RequestNumber == approveInfo.requestNumber).SingleOrDefault();
                missionReq.Comments = approveInfo.comments;
                missionService.Update(missionReq);
                response = Request.CreateResponse(HttpStatusCode.OK, "Success");
                tes.Complete();
            }

            return response;
        }
        [HttpGet]
        [Route("api/MDMAPI/GetMissionByRequestNumber/{requestNumber}")]
        public HttpResponseMessage GetMissionByRequestNumber(string requestNumber)
        {
            HttpResponseMessage response = null;
            try
            {
                var allowSubmit = workFlowService.IsAllowtoSubmit("MS", User.Identity.GetUserId(), requestNumber);
                var mission = missionService.GetAll().Where(MS => MS.RequestNumber == requestNumber).ToList();
                mission.ForEach(p => p.IsAllowtoSubmit = allowSubmit);
                if (IsLastLevelApproval("MS", requestNumber))
                {
                    mission.ForEach(c => c.Level = true);
                }
                else
                {
                    mission.ForEach(c => c.Level = false);
                }
                response = Request.CreateResponse(HttpStatusCode.OK, mission);
                return response;
            }
            catch (Exception Ex)
            {
                return null;
            }
        }
        [HttpGet]
        [Route("api/MDMAPI/IsExistingMissionCode/{missioncode}/{id}")]
        public bool IsExistingMissionCode(string missioncode, int id)
        {
            var missionList = new List<Mission>();
            if (id == 0)
            {
                missionList = missionService.GetAll().Where(t => t.Code == missioncode).ToList();
            }
            else
            {
                missionList = missionService.GetAll().Where(t => t.Code == missioncode && t.Id != id).ToList();
            }
            bool isexists = false;
            if (missionList.Count > 0)
            {
                isexists = true;
            }
            return isexists;
        }
        #endregion

        #region Tax
        [HttpGet]
        public HttpResponseMessage GetTax()
        {
            HttpResponseMessage response = null;
            try
            {
                var workflow = workFlowStatusService.GetAll().Where(WF => WF.MasterId == "TX").Select(WF => new { WF.Requestnumber, WF.Id, WF.WorkFlowId }).ToList();
                var Tax = taxService.GetAll().Where(TX => !workflow.Any(WS => WS.Requestnumber == TX.RequestNumber) && TX.CreatedBy == User.Identity.Name && !string.IsNullOrEmpty(TX.RequestNumber)).OrderByDescending(m => m.Id).ToList();
                Tax.ForEach(c => c.Level = true);
                response = Request.CreateResponse(HttpStatusCode.OK, Tax);

                return response;
            }
            catch (Exception Ex)
            {
                return null;
            }
        }
        [HttpGet]
        public HttpResponseMessage LoadTaxFieldAccess()
        {
            try
            {
                HttpResponseMessage response = null;
                TaxDetail Tax = new TaxDetail();
                Tax.objTax = new Tax();
                Tax.metaTableList = metaTableService.GetAll().Where(f => f.MasterCode == "TX").ToList();
                Tax.countryList = countryService.GetAll().Where(W => W.IsDelete == null ? true : W.IsDelete == false ? true : false).Select(F => new DropdownColumn() { id = F.Id, name = F.Code + " | " + F.Name }).ToList<DropdownColumn>();
                Tax.taxTypeList = taxTypeService.GetAll().Where(W => W.IsDelete == null ? true : W.IsDelete == false ? true : false).Select(F => new DropdownColumn() { id = F.Id, name = F.TaxTypeCode + " | " + F.TaxType1 }).ToList<DropdownColumn>();
                Tax.IsWorflowAssigned = workFlowService.GetID("TX") > 0 ? true : false;
                response = Request.CreateResponse(HttpStatusCode.OK, Tax);
                return response;
            }
            catch (Exception Ex)
            {
                return null;
            }
        }
        [HttpPost]
        [Route("api/MDMAPI/AddTax/{IsSubmit}")]
        public HttpResponseMessage AddTax(Tax Tax, bool IsSubmit)
        {

            HttpResponseMessage response = null;
            try
            {
                if (!ModelState.IsValid)
                {
                    response = Request.CreateResponse(HttpStatusCode.InternalServerError, BadRequest(ModelState));
                    return response;
                }
                using (var t = new TransactionScope())
                {
                    if (Tax.Id == 0)
                    {
                        Tax.CreatedBy = User.Identity.Name;
                        Tax.CreatedDate = DateTime.Now;
                        Tax.RequestNumber = "TX" + Helper.GetRandomNumber();
                        taxService.Insert(Tax);

                    }
                    else
                    {
                        Tax.ModifiedBy = User.Identity.Name;
                        Tax.ModifiedDate = DateTime.Now;
                        taxService.Update(Tax);
                    }
                    if (IsSubmit)
                    {
                        CreateWorkflow("TX", Tax.RequestNumber, Tax.Comments);
                    }
                    t.Complete();
                }
                response = Request.CreateResponse(HttpStatusCode.OK, "Successfully Inserted");
                return response;
            }
            catch (Exception Ex)
            {
                return null;
            }
        }
        [HttpPost]
        public HttpResponseMessage ApproveTax(ApproveInfo approveInfo)
        {
            HttpResponseMessage response = null;
            using (var tes = new TransactionScope())
            {
                ApproveWorkflow("TX", approveInfo.requestNumber, approveInfo.status, approveInfo.comments);
                taxService.Update(approveInfo.TaxData);
                response = Request.CreateResponse(HttpStatusCode.OK, "Success");
                tes.Complete();
            }

            return response;
        }
        [HttpGet]
        [Route("api/MDMAPI/GetTaxByRequestNumber/{requestNumber}")]
        public HttpResponseMessage GetTaxByRequestNumber(string requestNumber)
        {
            HttpResponseMessage response = null;
            try
            {
                var allowSubmit = workFlowService.IsAllowtoSubmit("TX", User.Identity.GetUserId(), requestNumber);
                var Tax = taxService.GetAll().Where(MS => MS.RequestNumber == requestNumber).ToList();
                Tax.ForEach(p => p.IsAllowtoSubmit = allowSubmit);
                if (IsLastLevelApproval("TX", requestNumber))
                {
                    Tax.ForEach(c => c.Level = true);
                }
                else
                {
                    Tax.ForEach(c => c.Level = false);
                }
                response = Request.CreateResponse(HttpStatusCode.OK, Tax);
                return response;
            }
            catch (Exception Ex)
            {
                return null;
            }
        }
        [HttpGet]
        [Route("api/MDMAPI/IsExistingTaxCode/{taxcode}/{id}")]
        public bool IsExistingTaxCode(string taxcode, int id)
        {
            var taxList = new List<Tax>();
            if (id == 0)
            {
                taxList = taxService.GetAll().Where(t => t.TaxCode == taxcode).ToList();
            }
            else
            {
                taxList = taxService.GetAll().Where(t => t.TaxCode == taxcode && t.Id != id).ToList();
            }
            bool isexists = false;
            if (taxList.Count > 0)
            {
                isexists = true;
            }
            return isexists;
        }
        #endregion

        #region SubRegion
        [HttpGet]
        public HttpResponseMessage GetSubRegion()
        {
            HttpResponseMessage response = null;
            try
            {
                //var regionList = regionService.GetAll().ToList();
                var workflow = workFlowStatusService.GetAll().Where(WF => WF.MasterId == "SRG").Select(WF => new { WF.Requestnumber }).ToList();
                //var regionList = regionService.GetAll().Where(CC => !workflow.Any(WS => WS.Requestnumber == CC.RequestNumber)).ToList();
                var subRegionList = subRegionService.GetAll().Where(SRG => !workflow.Any(WS => WS.Requestnumber == SRG.RequestNumber) && SRG.CreatedBy == User.Identity.Name && !string.IsNullOrEmpty(SRG.RequestNumber)).OrderByDescending(m => m.Id).ToList();
                subRegionList.ForEach(c => c.Level = true);
                response = Request.CreateResponse(HttpStatusCode.OK, subRegionList);
                return response;

            }
            catch (Exception Ex)
            {
                return null;
            }
        }

        [HttpGet]
        [Route("api/MDMAPI/LoadSubRegionDropdownList/{Id}")]
        public HttpResponseMessage LoadSubRegionDropdownList(int Id)
        {
            try
            {
                SubRegionDetails subregiondetails = new SubRegionDetails();
                HttpResponseMessage response = null;
                subregiondetails = subRegionService.Getdrodowndata(Id);
                if (Id == 0)
                {
                    subregiondetails.objSubRegion = new SubRegion();
                }
                else
                    subregiondetails.objSubRegion = null;
                subregiondetails.IsWorflowAssigned = workFlowService.GetID("SRG") > 0 ? true : false;
                response = Request.CreateResponse(HttpStatusCode.OK, subregiondetails);
                return response;
                #region Commented removing code from WebAPI to Repository
                //assetdetails.MetaTableList = metaTableService.GetAll().Where(f => f.MasterCode == "AS").ToList();
                //assetdetails.activetypeList = activeTypeService.GetAll().Where(W => W.IsDelete == null ? true : W.IsDelete == false ? true : false).Select(F => new DropdownColumn() { id = F.Id, name = F.Code + "|" + F.Name }).ToList<DropdownColumn>();

                //assetdetails.IsWorflowAssigned = workFlowService.GetID("AS") > 0 ? true : false;
                ////response = Request.CreateResponse(HttpStatusCode.OK, assetdetails);
                //return response;
                #endregion
            }
            catch (Exception Ex)
            {
                return null;
            }
        }
        [HttpPost]
        [Route("api/MDMAPI/AddSubRegion/{IsSubmit}")]
        public HttpResponseMessage AddSubRegion(SubRegion subregion, bool IsSubmit)
        {
            HttpResponseMessage response = null;
            try
            {
                if (!IsSubmit)
                {
                    ModelState.Remove("subregion.AditionalWorkflowId");
                }
                if (!ModelState.IsValid)
                {
                    response = Request.CreateResponse(HttpStatusCode.InternalServerError, BadRequest(ModelState));
                    return response;
                }



                subregion.IsDelete = false;
                if (subregion.Id == 0)
                {
                    subregion.RequestNumber = "SRG" + Helper.GetRandomNumber();
                    subregion.CreatedBy = User.Identity.Name;
                    subregion.CreatedDate = DateTime.Now;
                    subRegionService.Insert(subregion);
                }
                else
                {
                    subregion.ModifiedBy = User.Identity.Name;
                    subregion.ModifiedDate = DateTime.Now;
                    subRegionService.Update(subregion);
                }
                if (IsSubmit)
                {
                    CreateWorkflow("SRG", subregion.RequestNumber, subregion.Comments, subregion.AditionalWorkflowId);
                }
                response = Request.CreateResponse(HttpStatusCode.OK, "Successfully Inserted");
                return response;
            }
            catch (Exception Ex)
            {
                return null;
            }
        }
        [HttpPost]
        public HttpResponseMessage ApproveSubRegion(ApproveInfo approveInfo)
        {
            HttpResponseMessage response = null;
            using (var tes = new TransactionScope())
            {
                if (approveInfo.finalLevedModifiedDataSubRegion != null)
                {
                    var subregion = subRegionService.SingleOrDefault(approveInfo.finalLevedModifiedDataSubRegion.Id);
                    subregion.RegionId = approveInfo.finalLevedModifiedDataSubRegion.RegionId;
                    if (!String.IsNullOrWhiteSpace(approveInfo.finalLevedModifiedDataSubRegion.SubRegionDescription))
                        subregion.SubRegionDescription = approveInfo.finalLevedModifiedDataSubRegion.SubRegionDescription;
                    if (!String.IsNullOrWhiteSpace(approveInfo.finalLevedModifiedDataSubRegion.SubRegionCode))
                        subregion.SubRegionCode = approveInfo.finalLevedModifiedDataSubRegion.SubRegionCode;

                    subregion.ModifiedBy = User.Identity.Name;
                    subregion.ModifiedDate = DateTime.Now;

                    subRegionService.Update(subregion);
                }
                ApproveWorkflow("SRG", approveInfo.requestNumber, approveInfo.status, approveInfo.comments);
                var subregionReq = subRegionService.GetAll().Where(A => A.RequestNumber == approveInfo.requestNumber).SingleOrDefault();
                subregionReq.Comments = approveInfo.comments;
                subRegionService.Update(subregionReq);

                response = Request.CreateResponse(HttpStatusCode.OK, "Success");
                tes.Complete();
            }
            return response;
        }

        [HttpGet]
        [Route("api/MDMAPI/GetSubRegionByRequestNumber/{requestNumber}")]
        public HttpResponseMessage GetSubRegionByRequestNumber(string requestNumber)
        {
            HttpResponseMessage response = null;
            try
            {
                var allowSubmit = workFlowService.IsAllowtoSubmit("SRG", User.Identity.GetUserId(), requestNumber);
                var SubRegion = subRegionService.GetAll().Where(MS => MS.RequestNumber == requestNumber).ToList();
                SubRegion.ForEach(p => p.IsAllowtoSubmit = allowSubmit);
                if (IsLastLevelApproval("SRG", requestNumber))
                {
                    SubRegion.ForEach(c => c.Level = true);
                }
                else
                {
                    SubRegion.ForEach(c => c.Level = false);
                }
                response = Request.CreateResponse(HttpStatusCode.OK, SubRegion);
                return response;
            }
            catch (Exception Ex)
            {
                return null;
            }
        }

        [HttpGet]
        [Route("api/MDMAPI/isExistingSubRegionCode/{subregioncode}/{id}")]
        public bool isExistingSubRegionCode(string subregioncode, int id)
        {
            var subRegionList = new List<SubRegion>();
            if (id == 0)
            {
                subRegionList = subRegionService.GetAll().Where(sr => sr.SubRegionCode == subregioncode).ToList();
            }
            else
            {
                subRegionList = subRegionService.GetAll().Where(sr => sr.SubRegionCode == subregioncode && sr.Id != id).ToList();
            }

            //var subregionCode = subRegionService.GetAll().Where(sr => sr.SubRegionCode == subregioncode).SingleOrDefault();
            bool isexists = false;
            if (subRegionList.Count > 0)
            {
                isexists = true;
            }
            return isexists;
        }
        #endregion

        #region WHT Tax
        [HttpGet]
        public HttpResponseMessage GetWHTTax()
        {
            HttpResponseMessage response = null;
            try
            {
                var workflow = workFlowStatusService.GetAll().Where(WF => WF.MasterId == "WHT").Select(WF => new { WF.Requestnumber, WF.Id, WF.WorkFlowId }).ToList();
                var whtTax = whtTaxService.GetAll().Where(WHT => !workflow.Any(WS => WS.Requestnumber == WHT.RequestNumber) && WHT.CreatedBy == User.Identity.Name && !string.IsNullOrEmpty(WHT.RequestNumber)).OrderByDescending(m => m.Id).ToList();
                whtTax.ForEach(c => c.Level = true);
                response = Request.CreateResponse(HttpStatusCode.OK, whtTax);

                return response;
            }
            catch (Exception Ex)
            {
                return null;
            }
        }
        [HttpGet]
        public HttpResponseMessage LoadWHTTaxFieldAccess()
        {
            try
            {
                HttpResponseMessage response = null;
                WHTTaxDetail whtTax = new WHTTaxDetail();
                whtTax.objWHTTax = new WHTTax();
                whtTax.metaTableList = metaTableService.GetAll().Where(f => f.MasterCode == "WHT").ToList();
                whtTax.countryList = countryService.GetAll().Where(W => W.IsDelete == null ? true : W.IsDelete == false ? true : false).Select(F => new DropdownColumn() { id = F.Id, name = F.Code + " | " + F.Name }).ToList<DropdownColumn>();
                whtTax.whtTaxTypeList = whtTaxTypeService.GetAll().Where(W => W.IsDelete == false ? true : false).Select(F => new DropdownColumn() { id = F.Id, name = F.Code + " | " + F.Description, parentId = F.CountryId }).ToList<DropdownColumn>();
                whtTax.whtTaxLawsList = whtTaxLawService.GetAll().Where(W => W.IsDelete == false ? true : false).Select(F => new DropdownColumn() { id = F.Id, name = F.Code + " | " + F.Description }).ToList<DropdownColumn>();
                whtTax.whtTaxKeyList = whtTaxKeyService.GetAll().Where(W => W.IsDelete == false ? true : false).Select(F => new DropdownColumn() { id = F.Id, name = F.Code + " | " + F.Description }).ToList<DropdownColumn>();
                whtTax.receipientTypeList = receipientTypeService.GetAll().Where(W => W.IsDelete == false ? true : false).Select(F => new DropdownColumn() { id = F.Id, name = F.Code + " | " + F.Description }).ToList<DropdownColumn>();
                whtTax.IsWorflowAssigned = workFlowService.GetID("WHT") > 0 ? true : false;
                response = Request.CreateResponse(HttpStatusCode.OK, whtTax);
                return response;
            }
            catch (Exception Ex)
            {
                return null;
            }
        }
        [HttpPost]
        [Route("api/MDMAPI/AddWHTTax/{IsSubmit}")]
        public HttpResponseMessage AddWHTTax(WHTTax whtTax, bool IsSubmit)
        {

            HttpResponseMessage response = null;
            try
            {
                if (!string.IsNullOrWhiteSpace(whtTax.From))
                {
                    whtTax.FromDate = DateTime.Parse(whtTax.From, new CultureInfo("en-CA"));
                }
                if (!string.IsNullOrWhiteSpace(whtTax.To))
                {
                    whtTax.ToDate = DateTime.Parse(whtTax.To, new CultureInfo("en-CA"));
                }
                ModelState.Remove("whtTax.fromDate");
                ModelState.Remove("whtTax.toDate");
                if (!ModelState.IsValid)
                {
                    response = Request.CreateResponse(HttpStatusCode.InternalServerError, BadRequest(ModelState));
                    return response;
                }
                using (var t = new TransactionScope())
                {
                    if (whtTax.Id == 0)
                    {
                        whtTax.CreatedBy = User.Identity.Name;
                        whtTax.CreatedOn = DateTime.Now;
                        whtTax.RequestNumber = "WHT" + Helper.GetRandomNumber();
                        whtTaxService.Insert(whtTax);

                    }
                    else
                    {
                        whtTax.ModifiedBy = User.Identity.Name;
                        whtTax.ModifiedOn = DateTime.Now;
                        whtTaxService.Update(whtTax);
                    }
                    if (IsSubmit)
                    {
                        CreateWorkflow("WHT", whtTax.RequestNumber, whtTax.Comments);
                    }
                    t.Complete();
                }
                response = Request.CreateResponse(HttpStatusCode.OK, "Successfully Inserted");
                return response;
            }
            catch (Exception Ex)
            {
                return null;
            }
        }
        [HttpPost]
        public HttpResponseMessage ApproveWHTTax(ApproveInfo approveInfo)
        {
            if (!string.IsNullOrWhiteSpace(approveInfo.WHTTaxData.From))
            {
                approveInfo.WHTTaxData.FromDate = DateTime.Parse(approveInfo.WHTTaxData.From, new CultureInfo("en-CA"));
            }
            if (!string.IsNullOrWhiteSpace(approveInfo.WHTTaxData.To))
            {
                approveInfo.WHTTaxData.ToDate = DateTime.Parse(approveInfo.WHTTaxData.To, new CultureInfo("en-CA"));
            }
            HttpResponseMessage response = null;
            using (var tes = new TransactionScope())
            {
                ApproveWorkflow("WHT", approveInfo.requestNumber, approveInfo.status, approveInfo.comments);
                whtTaxService.Update(approveInfo.WHTTaxData);
                response = Request.CreateResponse(HttpStatusCode.OK, "Success");
                tes.Complete();
            }

            return response;
        }
        [HttpGet]
        [Route("api/MDMAPI/GetWHTTaxByRequestNumber/{requestNumber}")]
        public HttpResponseMessage GetWHTTaxByRequestNumber(string requestNumber)
        {
            HttpResponseMessage response = null;
            try
            {
                var allowSubmit = workFlowService.IsAllowtoSubmit("WHT", User.Identity.GetUserId(), requestNumber);
                var whtTax = whtTaxService.GetAll().Where(MS => MS.RequestNumber == requestNumber).ToList();
                whtTax.ForEach(p => p.IsAllowtoSubmit = allowSubmit);
                if (IsLastLevelApproval("WHT", requestNumber))
                {
                    whtTax.ForEach(c => c.Level = true);
                }
                else
                {
                    whtTax.ForEach(c => c.Level = false);
                }
                response = Request.CreateResponse(HttpStatusCode.OK, whtTax);
                return response;
            }
            catch (Exception Ex)
            {
                return null;
            }
        }
        [HttpGet]
        [Route("api/MDMAPI/IsExistingWHTTaxCode/{whtTaxcode}/{id}")]
        public bool IsExistingWHTTaxCode(string whtTaxcode, int id)
        {

            var whtTaxList = new List<WHTTax>();
            if (id == 0)
            {
                whtTaxList = whtTaxService.GetAll().Where(t => t.WHTTaxCode == whtTaxcode).ToList();
            }
            else
            {
                whtTaxList = whtTaxService.GetAll().Where(t => t.WHTTaxCode == whtTaxcode && t.Id != id).ToList();
            }
            bool isexists = false;
            if (whtTaxList.Count > 0)
            {
                isexists = true;
            }
            return isexists;
        }
        #endregion

        #region Customer
        [HttpGet]
        public HttpResponseMessage GetCustomer()
        {
            HttpResponseMessage response = null;
            try
            {
                var workflow = workFlowStatusService.GetAll().Where(WF => WF.MasterId == "CUS").Select(WF => new { WF.Requestnumber, WF.Id, WF.WorkFlowId }).ToList();
                var customer = customerTransactionService.GetAll().Where(CUS => !workflow.Any(WS => WS.Requestnumber == CUS.RequestNumber) && CUS.CreatedBy == User.Identity.Name && !string.IsNullOrEmpty(CUS.RequestNumber)).OrderByDescending(m => m.Id).ToList();
                customer.ForEach(c => c.Level = true);
                response = Request.CreateResponse(HttpStatusCode.OK, customer);
                return response;
            }
            catch (Exception Ex)
            {
                return null;
            }
        }
        [HttpGet]
        public HttpResponseMessage LoadCustomerDropdowns()
        {
            try
            {
                HttpResponseMessage response = null;
                var customer = customerTransactionService.LoadCustomerDropDowns();
                customer.IsWorflowAssigned = workFlowService.GetID("CUS") > 0 ? true : false;
                response = Request.CreateResponse(HttpStatusCode.OK, customer);
                return response;
            }
            catch (Exception Ex)
            {
                return null;
            }
        }
        [HttpPost]
        [Route("api/MDMAPI/AddCustomer/{IsSubmit}")]
        public HttpResponseMessage AddCustomer(CustomerTransaction customerTransaction, bool IsSubmit)
        {
            HttpResponseMessage response = null;
            try
            {
                if (customerTransaction.lstCustomerWithholdingTaxs != null)
                {
                    foreach (var objCustomerWHT in customerTransaction.lstCustomerWithholdingTaxs)
                    {
                        if (!string.IsNullOrWhiteSpace(objCustomerWHT.From))
                        {
                            objCustomerWHT.FromDate = DateTime.Parse(objCustomerWHT.From, new CultureInfo("en-CA"));
                        }
                        if (!string.IsNullOrWhiteSpace(objCustomerWHT.To))
                        {
                            objCustomerWHT.ToDate = DateTime.Parse(objCustomerWHT.To, new CultureInfo("en-CA"));
                        }
                        ModelState.Remove("objCustomerWHT.fromDate");
                        ModelState.Remove("objCustomerWHT.toDate");
                    }
                }
                if (!string.IsNullOrWhiteSpace(customerTransaction.DunningProcedureDate))
                {
                    customerTransaction.DateOfDunningProcedure = DateTime.Parse(customerTransaction.DunningProcedureDate, new CultureInfo("en-CA"));
                }
                if (!string.IsNullOrWhiteSpace(customerTransaction.LastDunnedDate))
                {
                    customerTransaction.LastDunned = DateTime.Parse(customerTransaction.LastDunnedDate, new CultureInfo("en-CA"));
                }
                ModelState.Remove("customerTransaction.fromDate");
                ModelState.Remove("customerTransaction.toDate");
                ModelState.Remove("customerTransaction.lastDunned");
                ModelState.Remove("customerTransaction.dateOfDunningProcedure");
                if (!ModelState.IsValid)
                {
                    response = Request.CreateResponse(HttpStatusCode.InternalServerError, BadRequest(ModelState));
                    return response;
                }
                using (var t = new TransactionScope())
                {
                    if (customerTransaction.Id == 0)
                    {
                        customerTransaction.CreatedBy = User.Identity.Name;
                        customerTransaction.CreatedOn = DateTime.Now;
                        customerTransaction.RequestNumber = "CUS" + Helper.GetRandomNumber();
                        customerTransactionService.Insert(customerTransaction);
                    }
                    else
                    {
                        customerTransaction.ModifiedBy = User.Identity.Name;
                        customerTransaction.ModifiedOn = DateTime.Now;
                        customerTransactionService.Update(customerTransaction);
                    }
                    if (customerTransaction.lstCustomerPaymentTransactions != null)
                    {
                        foreach (var objCustomer in customerTransaction.lstCustomerPaymentTransactions)
                        {
                            if (objCustomer.Id == 0)
                            {
                                objCustomer.CustomerTransactionId = customerTransaction.Id;
                                objCustomer.CreatedBy = User.Identity.Name;
                                objCustomer.CreatedDate = DateTime.Now;
                                customerPaymentTransactionService.Insert(objCustomer);
                            }
                            else
                            {
                                objCustomer.ModifiedBy = User.Identity.Name;
                                objCustomer.ModifiedDate = DateTime.Now;
                                customerPaymentTransactionService.Update(objCustomer);
                            }
                        }
                    }
                    if (customerTransaction.lstCustomerWithholdingTaxs != null)
                    {
                        foreach (var objCustomerWHT in customerTransaction.lstCustomerWithholdingTaxs)
                        {
                            if (objCustomerWHT.Id == 0)
                            {
                                objCustomerWHT.CustomerTransactionId = customerTransaction.Id;
                                objCustomerWHT.CreatedBy = User.Identity.Name;
                                objCustomerWHT.CreatedDate = DateTime.Now;
                                customerWithholdingTaxService.Insert(objCustomerWHT);
                            }
                            else
                            {
                                objCustomerWHT.ModifiedBy = User.Identity.Name;
                                objCustomerWHT.ModifiedDate = DateTime.Now;
                                customerWithholdingTaxService.Update(objCustomerWHT);
                            }
                        }
                    }
                    if (customerTransaction.lstCustomerPaymentMethod != null)
                    {
                        foreach (var objCustomerPaymentMethod in customerTransaction.lstCustomerPaymentMethod)
                        {
                            if (objCustomerPaymentMethod.Id == 0)
                            {
                                objCustomerPaymentMethod.CustomerTransactionId = customerTransaction.Id;
                                objCustomerPaymentMethod.CreatedBy = User.Identity.Name;
                                objCustomerPaymentMethod.CreatedDate = DateTime.Now;
                                customerPaymentMethodService.Insert(objCustomerPaymentMethod);
                            }
                            else
                            {
                                objCustomerPaymentMethod.CustomerTransactionId = customerTransaction.Id;
                                objCustomerPaymentMethod.ModifiedBy = User.Identity.Name;
                                objCustomerPaymentMethod.ModifiedDate = DateTime.Now;
                                customerPaymentMethodService.Update(objCustomerPaymentMethod);
                            }
                        }
                    }
                    if (IsSubmit)
                    {
                        CreateWorkflow("CUS", customerTransaction.RequestNumber, customerTransaction.Comments, customerTransaction.AdditionalWorkflowId);
                    }
                    t.Complete();
                }
                response = Request.CreateResponse(HttpStatusCode.OK, "Successfully Inserted");
                return response;
            }
            catch (Exception Ex)
            {
                return null;
            }
        }
        [HttpPost]
        public HttpResponseMessage ApproveCustomer(ApproveInfo approveInfo)
        {
            if (approveInfo.finalLevedModifiedDataCustomer.lstCustomerWithholdingTaxs != null)
            {
                foreach (var objCustomerWHT in approveInfo.finalLevedModifiedDataCustomer.lstCustomerWithholdingTaxs)
                {
                    if (!string.IsNullOrWhiteSpace(objCustomerWHT.From))
                    {
                        objCustomerWHT.FromDate = DateTime.Parse(objCustomerWHT.From, new CultureInfo("en-CA"));
                    }
                    if (!string.IsNullOrWhiteSpace(objCustomerWHT.To))
                    {
                        objCustomerWHT.ToDate = DateTime.Parse(objCustomerWHT.To, new CultureInfo("en-CA"));
                    }
                    ModelState.Remove("objCustomerWHT.fromDate");
                    ModelState.Remove("objCustomerWHT.toDate");
                }
            }
            if (!string.IsNullOrWhiteSpace(approveInfo.finalLevedModifiedDataCustomer.DunningProcedureDate))
            {
                approveInfo.finalLevedModifiedDataCustomer.DateOfDunningProcedure = DateTime.Parse(approveInfo.finalLevedModifiedDataCustomer.DunningProcedureDate, new CultureInfo("en-CA"));
            }
            if (!string.IsNullOrWhiteSpace(approveInfo.finalLevedModifiedDataCustomer.LastDunnedDate))
            {
                approveInfo.finalLevedModifiedDataCustomer.LastDunned = DateTime.Parse(approveInfo.finalLevedModifiedDataCustomer.LastDunnedDate, new CultureInfo("en-CA"));
            }
            HttpResponseMessage response = null;
            using (var tes = new TransactionScope())
            {
                ApproveWorkflow("CUS", approveInfo.requestNumber, approveInfo.status, approveInfo.comments);
                customerTransactionService.Update(approveInfo.finalLevedModifiedDataCustomer);
                //PaymentTransaction
                if (approveInfo.finalLevedModifiedDataCustomer.lstCustomerPaymentTransactions != null)
                {
                    foreach (var objCustomer in approveInfo.finalLevedModifiedDataCustomer.lstCustomerPaymentTransactions)
                    {
                        if (objCustomer.Id == 0)
                        {
                            objCustomer.CustomerTransactionId = approveInfo.finalLevedModifiedDataCustomer.Id;
                            objCustomer.CreatedBy = User.Identity.Name;
                            objCustomer.CreatedDate = DateTime.Now;
                            customerPaymentTransactionService.Insert(objCustomer);
                        }
                        else
                        {
                            objCustomer.ModifiedBy = User.Identity.Name;
                            objCustomer.ModifiedDate = DateTime.Now;
                            customerPaymentTransactionService.Update(objCustomer);
                        }
                    }
                }
                //WHT
                if (approveInfo.finalLevedModifiedDataCustomer.lstCustomerWithholdingTaxs != null)
                {
                    foreach (var objCustomerWHT in approveInfo.finalLevedModifiedDataCustomer.lstCustomerWithholdingTaxs)
                    {
                        if (objCustomerWHT.Id == 0)
                        {
                            objCustomerWHT.CustomerTransactionId = approveInfo.finalLevedModifiedDataCustomer.Id;
                            objCustomerWHT.CreatedBy = User.Identity.Name;
                            objCustomerWHT.CreatedDate = DateTime.Now;
                            customerWithholdingTaxService.Insert(objCustomerWHT);
                        }
                        else
                        {
                            objCustomerWHT.ModifiedBy = User.Identity.Name;
                            objCustomerWHT.ModifiedDate = DateTime.Now;
                            customerWithholdingTaxService.Update(objCustomerWHT);
                        }
                    }
                }
                response = Request.CreateResponse(HttpStatusCode.OK, "Success");
                tes.Complete();
            }

            return response;
        }
        [HttpGet]
        [Route("api/MDMAPI/GetCustomerByRequestNumber/{requestNumber}")]
        public HttpResponseMessage GetCustomerByRequestNumber(string requestNumber)
        {
            HttpResponseMessage response = null;
            try
            {
                var allowSubmit = workFlowService.IsAllowtoSubmit("CUS", User.Identity.GetUserId(), requestNumber);
                var customer = customerTransactionService.GetAll().Where(MS => MS.RequestNumber == requestNumber).ToList();
                customer.ForEach(p => p.IsAllowtoSubmit = allowSubmit);
                if (IsLastLevelApproval("CUS", requestNumber))
                {
                    customer.ForEach(c => c.Level = false);
                }
                else
                {
                    customer.ForEach(c => c.Level = true);
                }
                response = Request.CreateResponse(HttpStatusCode.OK, customer);
                return response;
            }
            catch (Exception Ex)
            {
                return null;
            }
        }
        [HttpGet]
        [Route("api/MDMAPI/IsExistingCustomerTransactionCode/{customerAccount}/{id}")]
        public bool IsExistingCustomerTransactionCode(string customerAccount, int id)
        {
            var CustomerList = new List<CustomerTransaction>();
            if (id == 0)
            {
                CustomerList = customerTransactionService.GetAll().Where(c => c.CustomerAccount == customerAccount).ToList();
            }
            else
            {
                CustomerList = customerTransactionService.GetAll().Where(c => c.CustomerAccount == customerAccount && c.Id != id).ToList();
            }
            bool isexists = false;
            if (CustomerList.Count > 0)
            {
                isexists = true;
            }
            return isexists;
        }
        #endregion

        #region Statistical Key Figure
        [HttpGet]
        public HttpResponseMessage GetStatisticalKey()
        {
            HttpResponseMessage response = null;
            try
            {
                var workflow = workFlowStatusService.GetAll().Where(WF => WF.MasterId == "SKF").Select(WF => new { WF.Requestnumber, WF.Id, WF.WorkFlowId }).ToList();
                var statisticalKey = statisticalKeyFigureService.GetAll().Where(SKF => !workflow.Any(WS => WS.Requestnumber == SKF.RequestNumber) && SKF.CreatedBy == User.Identity.Name && !string.IsNullOrEmpty(SKF.RequestNumber)).OrderByDescending(m => m.Id).ToList();
                statisticalKey.ForEach(c => c.Level = true);
                response = Request.CreateResponse(HttpStatusCode.OK, statisticalKey);

                return response;
            }
            catch (Exception Ex)
            {
                return null;
            }
        }
        [HttpGet]
        public HttpResponseMessage LoadStatisticalKeyDropdowns()
        {
            try
            {
                HttpResponseMessage response = null;
                StatisticalKeyDetail statisticalKey = new StatisticalKeyDetail();
                statisticalKey.objStatisticalKey = new StatisticalKeyFigure();
                statisticalKey.metaTableList = metaTableService.GetAll().Where(f => f.MasterCode == "SKF").ToList();
                statisticalKey.statisticalKeyFigureUnitList = statisticalKeyFigureUnitService.GetAll().Where(W => W.IsDelete == null ? true : W.IsDelete == false ? true : false).Select(F => new DropdownColumn() { id = F.Id, name = F.Code + " | " + F.Description }).ToList<DropdownColumn>();
                statisticalKey.IsWorflowAssigned = workFlowService.GetID("SKF") > 0 ? true : false;
                response = Request.CreateResponse(HttpStatusCode.OK, statisticalKey);
                return response;
            }
            catch (Exception Ex)
            {
                return null;
            }
        }
        [HttpPost]
        [Route("api/MDMAPI/AddstatiticalKey/{IsSubmit}")]
        public HttpResponseMessage AddstatiticalKey(StatisticalKeyFigure statisticalKeyFigure, bool IsSubmit)
        {
            HttpResponseMessage response = null;
            try
            {
                if (!ModelState.IsValid)
                {
                    response = Request.CreateResponse(HttpStatusCode.InternalServerError, BadRequest(ModelState));
                    return response;
                }
                using (var t = new TransactionScope())
                {
                    if (statisticalKeyFigure.Id == 0)
                    {
                        statisticalKeyFigure.CreatedBy = User.Identity.Name;
                        statisticalKeyFigure.CreatedOn = DateTime.Now;
                        statisticalKeyFigure.RequestNumber = "SKF" + Helper.GetRandomNumber();
                        statisticalKeyFigureService.Insert(statisticalKeyFigure);

                    }
                    else
                    {
                        statisticalKeyFigure.ModifiedBy = User.Identity.Name;
                        statisticalKeyFigure.ModifiedOn = DateTime.Now;
                        statisticalKeyFigureService.Update(statisticalKeyFigure);
                    }
                    if (IsSubmit)
                    {
                        CreateWorkflow("SKF", statisticalKeyFigure.RequestNumber, statisticalKeyFigure.Comments);
                    }
                    t.Complete();
                }
                response = Request.CreateResponse(HttpStatusCode.OK, "Successfully Inserted");
                return response;
            }
            catch (Exception Ex)
            {
                return null;
            }
        }
        [HttpPost]
        public HttpResponseMessage ApproveStatisticalKey(ApproveInfo approveInfo)
        {
            HttpResponseMessage response = null;
            using (var tes = new TransactionScope())
            {
                ApproveWorkflow("SKF", approveInfo.requestNumber, approveInfo.status, approveInfo.comments);
                statisticalKeyFigureService.Update(approveInfo.statisticalKey);
                response = Request.CreateResponse(HttpStatusCode.OK, "Success");
                tes.Complete();
            }

            return response;
        }
        [HttpGet]
        [Route("api/MDMAPI/GetStatisticalKeyByRequestNumber/{requestNumber}")]
        public HttpResponseMessage GetStatisticalKeyByRequestNumber(string requestNumber)
        {
            HttpResponseMessage response = null;
            try
            {
                var allowSubmit = workFlowService.IsAllowtoSubmit("SKF", User.Identity.GetUserId(), requestNumber);
                var statisticalKey = statisticalKeyFigureService.GetAll().Where(MS => MS.RequestNumber == requestNumber).ToList();
                statisticalKey.ForEach(p => p.IsAllowtoSubmit = allowSubmit);
                if (IsLastLevelApproval("SKF", requestNumber))
                {
                    statisticalKey.ForEach(c => c.Level = false);
                }
                else
                {
                    statisticalKey.ForEach(c => c.Level = true);
                }
                response = Request.CreateResponse(HttpStatusCode.OK, statisticalKey);
                return response;
            }
            catch (Exception Ex)
            {
                return null;
            }
        }
        [HttpGet]
        [Route("api/MDMAPI/IsExistingStatisticalKeyCode/{statisticalKeyFigure}/{id}")]
        public bool IsExistingStatisticalKeyCode(string statisticalKeyFigure, int id)
        {
            var statisticalKeyList = new List<StatisticalKeyFigure>();
            if (id == 0)
            {
                statisticalKeyList = statisticalKeyFigureService.GetAll().Where(t => t.StatisticalKeyFigure1 == statisticalKeyFigure).ToList();
            }
            else
            {
                statisticalKeyList = statisticalKeyFigureService.GetAll().Where(t => t.StatisticalKeyFigure1 == statisticalKeyFigure && t.Id != id).ToList();
            }
            bool isexists = false;
            if (statisticalKeyList.Count > 0)
            {
                isexists = true;
            }
            return isexists;
        }
        #endregion

        #region Currency
        [HttpGet]
        public HttpResponseMessage GetCurrency()
        {
            HttpResponseMessage response = null;
            try
            {
                //var regionList = regionService.GetAll().ToList();
                var workflow = workFlowStatusService.GetAll().Where(WF => WF.MasterId == "CUR").Select(WF => new { WF.Requestnumber }).ToList();
                //var regionList = regionService.GetAll().Where(CC => !workflow.Any(WS => WS.Requestnumber == CC.RequestNumber)).ToList();
                var currencyList = currencyService.GetAll().Where(CUR => !workflow.Any(WS => WS.Requestnumber == CUR.RequestNumber) && CUR.CreatedBy == User.Identity.Name && !string.IsNullOrEmpty(CUR.RequestNumber)).OrderByDescending(m => m.Id).ToList();
                currencyList.ForEach(c => c.Level = true);
                response = Request.CreateResponse(HttpStatusCode.OK, currencyList);
                return response;

            }
            catch (Exception Ex)
            {
                return null;
            }
        }

        [HttpGet]
        [Route("api/MDMAPI/LoadCurrency/{Id}")]
        public HttpResponseMessage LoadCurrency(int Id)
        {

            HttpResponseMessage response = null;
            CurrencyData currencyData = new CurrencyData();
            if (Id == 0)
            {
                currencyData.objCurrency = new Currency();
            }
            else
            {
                currencyData.objCurrency = null;
            }
            currencyData.MetaTableList = metaTableService.GetAll().Where(f => f.MasterCode == "CUR").ToList();
            // profitCenter.MetaTableList = metaTableService.GetAll().Where(f => f.MasterCode == "PC").ToList();
            //regionData.objRegion = regionService.GetAll().Where(Rg => Rg.Id == Id).ToList();
            currencyData.IsWorflowAssigned = workFlowService.GetID("CUR") > 0 ? true : false;

            response = Request.CreateResponse(HttpStatusCode.OK, currencyData);
            return response;
        }
        [HttpPost]
        [Route("api/MDMAPI/AddCurrency/{IsSubmit}")]
        public HttpResponseMessage AddCurrency(Currency currency, bool IsSubmit)
        {
            HttpResponseMessage response = null;
            try
            {
                if (!string.IsNullOrWhiteSpace(currency.strCurrencyValidDate))
                {
                    currency.CurrencyValidDate = DateTime.Parse(currency.strCurrencyValidDate, new CultureInfo("en-CA"));
                }
                ModelState.Remove("currency.currencyValidDate");
                if (!ModelState.IsValid)
                {
                    response = Request.CreateResponse(HttpStatusCode.InternalServerError, BadRequest(ModelState));
                    return response;
                }
                if (currency.Id == 0)
                {
                    currency.CreatedBy = User.Identity.Name;
                    currency.CreatedDate = DateTime.Now;
                    currency.RequestNumber = "CUR" + Helper.GetRandomNumber();

                    currency.IsDelete = false;
                    int i = currencyService.Insert(currency);
                }
                else
                {
                    currency.ModifiedBy = User.Identity.Name;
                    currency.ModifiedDate = DateTime.Now;
                    currencyService.Update(currency);
                }
                if (IsSubmit)
                {
                    if (string.IsNullOrWhiteSpace(currency.Comments))
                    {
                        currency.Comments = "Created By Currency";
                    }
                    CreateWorkflow("CUR", currency.RequestNumber, currency.Comments);
                }
                response = Request.CreateResponse(HttpStatusCode.OK, "Successfully Inserted");
                return response;
            }
            catch (Exception Ex)
            {
                return null;
            }
        }
        [HttpPost]
        public HttpResponseMessage ApproveCurrency(ApproveInfo approveInfo)
        {
            HttpResponseMessage response = null;
            using (var tes = new TransactionScope())
            {
                if (approveInfo.finalLevedModifiedDataCurrency != null)
                {
                    var currency = currencyService.SingleOrDefault(approveInfo.finalLevedModifiedDataCurrency.Id);
                    currency.Id = approveInfo.finalLevedModifiedDataCurrency.Id;
                    if (!String.IsNullOrWhiteSpace(approveInfo.finalLevedModifiedDataCurrency.Description))
                        currency.Description = approveInfo.finalLevedModifiedDataCurrency.Description;
                    if (!String.IsNullOrWhiteSpace(approveInfo.finalLevedModifiedDataCurrency.ShortText))
                        currency.ShortText = approveInfo.finalLevedModifiedDataCurrency.ShortText;
                    if (!String.IsNullOrWhiteSpace(approveInfo.finalLevedModifiedDataCurrency.Code))
                        currency.Code = approveInfo.finalLevedModifiedDataCurrency.Code;
                    if (approveInfo.finalLevedModifiedDataCurrency.CurrencyValidDate != null)
                    {
                        currency.CurrencyValidDate = DateTime.Parse(currency.strCurrencyValidDate, new CultureInfo("en-CA"));
                    }
                    ModelState.Remove("currency.currencyValidDate");
                    if (!ModelState.IsValid)
                    {
                        response = Request.CreateResponse(HttpStatusCode.InternalServerError, BadRequest(ModelState));
                        return response;
                    }
                    currency.ModifiedBy = User.Identity.Name;
                    currency.ModifiedDate = DateTime.Now;

                    currencyService.Update(currency);
                }
                ApproveWorkflow("CUR", approveInfo.requestNumber, approveInfo.status, approveInfo.comments);
                var currencyReq = currencyService.GetAll().Where(A => A.RequestNumber == approveInfo.requestNumber).SingleOrDefault();
                currencyReq.Comments = approveInfo.comments;
                currencyService.Update(currencyReq);

                response = Request.CreateResponse(HttpStatusCode.OK, "Success");
                tes.Complete();
            }
            return response;
        }
        [HttpGet]
        [Route("api/MDMAPI/GetCurrencyByRequestNumber/{requestNumber}")]
        public HttpResponseMessage GetCurrencyByRequestNumber(string requestNumber)
        {
            HttpResponseMessage response = null;
            try
            {
                var allowSubmit = workFlowService.IsAllowtoSubmit("CUR", User.Identity.GetUserId(), requestNumber);
                var Currency = currencyService.GetAll().Where(MS => MS.RequestNumber == requestNumber).ToList();
                Currency.ForEach(p => p.IsAllowtoSubmit = allowSubmit);
                if (IsLastLevelApproval("CUR", requestNumber))
                {
                    Currency.ForEach(c => c.Level = true);
                }
                else
                {
                    Currency.ForEach(c => c.Level = false);
                }
                response = Request.CreateResponse(HttpStatusCode.OK, Currency);
                return response;
            }
            catch (Exception Ex)
            {
                return null;
            }
        }

        [HttpGet]
        [Route("api/MDMAPI/isExistingCurrencyCode/{currencycode}/{id}")]
        public bool isExistingCurrencyCode(string currencycode, int id)
        {
            var currencyList = new List<Currency>();
            if (id == 0)
            {
                currencyList = currencyService.GetAll().Where(c => c.Code == currencycode).ToList();
            }
            else
            {
                currencyList = currencyService.GetAll().Where(c => c.Code == currencycode && c.Id != id).ToList();
            }

            //var currencyCode = currencyService.GetAll().Where(c => c.Code == currencycode).SingleOrDefault();
            bool isexists = false;
            if (currencyList.Count > 0)
            {
                isexists = true;
            }
            return isexists;
        }
        #endregion

        #region Internal Order
        [HttpGet]
        [Route("api/MDMAPI/LoadInternalOrder/{Id}")]
        public HttpResponseMessage LoadInternalOrder(int Id)
        {

            HttpResponseMessage response = null;
            InternalOrderData internalOrderData = new InternalOrderData();
            if (Id == 0)
            {
                internalOrderData.objInternalOrder = new InternalOrder();
            }
            else
            {
                internalOrderData.objInternalOrder = null;
            }
            internalOrderData.MetaTableList = metaTableService.GetAll().Where(f => f.MasterCode == "IO").ToList();
            // profitCenter.MetaTableList = metaTableService.GetAll().Where(f => f.MasterCode == "PC").ToList();
            //regionData.objRegion = regionService.GetAll().Where(Rg => Rg.Id == Id).ToList();
            internalOrderData.IsWorkflowAssigned = workFlowService.GetID("IO") > 0 ? true : false;

            response = Request.CreateResponse(HttpStatusCode.OK, internalOrderData);
            return response;
        }
        [HttpGet]
        public HttpResponseMessage GetInternalOrder()
        {
            HttpResponseMessage response = null;
            try
            {
                //var regionList = regionService.GetAll().ToList();
                var workflow = workFlowStatusService.GetAll().Where(WF => WF.MasterId == "IO").Select(WF => new { WF.Requestnumber }).ToList();
                //var regionList = regionService.GetAll().Where(CC => !workflow.Any(WS => WS.Requestnumber == CC.RequestNumber)).ToList();
                var internalOrderList = internalOrderService.GetAll().Where(CUR => !workflow.Any(WS => WS.Requestnumber == CUR.RequestNumber) && CUR.CreatedBy == User.Identity.Name && !string.IsNullOrEmpty(CUR.RequestNumber)).OrderByDescending(m => m.Id).ToList();
                internalOrderList.ForEach(c => c.Level = true);
                response = Request.CreateResponse(HttpStatusCode.OK, internalOrderList);
                return response;

            }
            catch (Exception Ex)
            {
                return null;
            }
        }

        [HttpGet]
        [Route("api/MDMAPI/LoadInternalOrderDropdownList/{Id}")]
        public HttpResponseMessage LoadInternalOrderDropdownList(int Id)
        {
            try
            {
                HttpResponseMessage response = null;
                var internalOrder = internalOrderService.GetDropDownData(Id);
                internalOrder.IsWorkflowAssigned = workFlowService.GetID("IO") > 0 ? true : false;
                response = Request.CreateResponse(HttpStatusCode.OK, internalOrder);
                return response;
                //InternalOrderDetails internalOrderDetails = new InternalOrderDetails();
                //HttpResponseMessage response = null;
                //internalOrderDetails = internalOrderService.GetDropDownData(Id);
                //if (Id == 0)
                //{
                //    internalOrderDetails.objInternalOrder = new InternalOrder();
                //}
                //else
                //    internalOrderDetails.objInternalOrder = null;
                //internalOrderDetails.IsWorkflowAssigned = workFlowService.GetID("IO") > 0 ? true : false;
                //response = Request.CreateResponse(HttpStatusCode.OK, internalOrderDetails);
                //return response;               
            }
            catch (Exception Ex)
            {
                return null;
            }
        }

        [HttpPost]
        [Route("api/MDMAPI/AddInternalOrder/{IsSubmit}")]
        public HttpResponseMessage AddInternalOrder(InternalOrder internalorder, bool IsSubmit)
        {

            HttpResponseMessage response = null;
            try
            {
                internalorder.IsDelete = false;
                using (var t = new TransactionScope())
                {
                    if (internalorder.Id == 0)
                    {
                        // This Area Need to Insert in BULK Insert Method                    
                        internalorder.CreatedBy = User.Identity.Name;
                        internalorder.CreatedDate = DateTime.Now;
                        internalorder.RequestNumber = Helper.GetMasterCode(Masters.InternalOrder) + Helper.GetRandomNumber();
                        internalOrderService.Insert(internalorder);

                    }
                    else
                    {
                        internalorder.ModifiedBy = User.Identity.Name;
                        internalorder.ModifiedDate = DateTime.Now;
                        internalOrderService.Update(internalorder);
                    }
                    if (IsSubmit)
                    {
                        CreateWorkflow(Helper.GetMasterCode(Masters.InternalOrder), internalorder.RequestNumber, internalorder.Comments, internalorder.AditionalWorkflowId);
                    }
                    t.Complete();
                }
                response = Request.CreateResponse(HttpStatusCode.OK, "Successfully Inserted");
                return response;
            }
            catch (Exception Ex)
            {
                return null;
            }
        }

        [HttpPost]
        public HttpResponseMessage ApproveInternalOrder(ApproveInfo approveInfo)
        {
            HttpResponseMessage response = null;
            using (var tes = new TransactionScope())
            {

                if (approveInfo.finalLevelModifiedInternalOrder != null)
                {
                    var internalorder = internalOrderService.SingleOrDefault(approveInfo.finalLevelModifiedInternalOrder.Id);
                    internalorder.ControllingAreaId = approveInfo.finalLevelModifiedInternalOrder.ControllingAreaId;
                    internalorder.OrderTypeId = approveInfo.finalLevelModifiedInternalOrder.OrderTypeId;
                    internalorder.OrderNumberId = approveInfo.finalLevelModifiedInternalOrder.OrderNumberId;
                    if (!string.IsNullOrWhiteSpace(approveInfo.finalLevelModifiedInternalOrder.Description))
                        internalorder.Description = approveInfo.finalLevelModifiedInternalOrder.Description;
                    internalorder.IsLongTextExist = approveInfo.finalLevelModifiedInternalOrder.IsLongTextExist;
                    internalorder.CompanyId = approveInfo.finalLevelModifiedInternalOrder.CompanyId;
                    internalorder.PlantId = approveInfo.finalLevelModifiedInternalOrder.PlantId;
                    internalorder.BusinessAreaId = approveInfo.finalLevelModifiedInternalOrder.BusinessAreaId;
                    internalorder.FunctionalAreaId = approveInfo.finalLevelModifiedInternalOrder.FunctionalAreaId;
                    internalorder.ObjectClassId = approveInfo.finalLevelModifiedInternalOrder.ObjectClassId;
                    internalorder.ProfitCenterId = approveInfo.finalLevelModifiedInternalOrder.ProfitCenterId;
                    internalorder.ResponsibleCostCenterId = approveInfo.finalLevelModifiedInternalOrder.ResponsibleCostCenterId;
                    internalorder.ResponsibleCompanyInterOrderId = approveInfo.finalLevelModifiedInternalOrder.ResponsibleCompanyInterOrderId;
                    internalorder.WBSElementId = approveInfo.finalLevelModifiedInternalOrder.WBSElementId;
                    internalorder.RequestedCostCenterId = approveInfo.finalLevelModifiedInternalOrder.RequestedCostCenterId;
                    internalorder.RequestedCompanyCodeId = approveInfo.finalLevelModifiedInternalOrder.RequestedCompanyCodeId;
                    internalorder.RequestOrderId = approveInfo.finalLevelModifiedInternalOrder.RequestOrderId;
                    internalorder.SalesOrderNumberId = approveInfo.finalLevelModifiedInternalOrder.SalesOrderNumberId;
                    internalorder.LocationId = approveInfo.finalLevelModifiedInternalOrder.LocationId;
                    if (!string.IsNullOrWhiteSpace(approveInfo.finalLevelModifiedInternalOrder.ExternalOrderNumber))
                        internalorder.ExternalOrderNumber = approveInfo.finalLevelModifiedInternalOrder.ExternalOrderNumber;
                    internalorder.OrderCurrencyId = approveInfo.finalLevelModifiedInternalOrder.OrderCurrencyId;
                    internalorder.OrderCategoryId = approveInfo.finalLevelModifiedInternalOrder.OrderCategoryId;
                    internalorder.IdentifierStatisticalOrder = approveInfo.finalLevelModifiedInternalOrder.IdentifierStatisticalOrder;
                    internalorder.PostedCostCenter = approveInfo.finalLevelModifiedInternalOrder.PostedCostCenter;
                    internalorder.IndigratedIndicator = approveInfo.finalLevelModifiedInternalOrder.IndigratedIndicator;
                    internalorder.ResultAnalysisKey = approveInfo.finalLevelModifiedInternalOrder.ResultAnalysisKey;
                    internalorder.CostingSheet = approveInfo.finalLevelModifiedInternalOrder.CostingSheet;
                    internalorder.Overhead_key = approveInfo.finalLevelModifiedInternalOrder.Overhead_key;
                    internalorder.OrderInterestCaliculation = approveInfo.finalLevelModifiedInternalOrder.OrderInterestCaliculation;
                    internalorder.SettlementCostElement = approveInfo.finalLevelModifiedInternalOrder.SettlementCostElement;
                    internalorder.BasicSettlementCostCenter = approveInfo.finalLevelModifiedInternalOrder.BasicSettlementCostCenter;
                    internalorder.BasicSettlementCostGLAccount = approveInfo.finalLevelModifiedInternalOrder.BasicSettlementCostGLAccount;
                    internalorder.Comments = approveInfo.finalLevelModifiedInternalOrder.Comments;
                    internalorder.Code = approveInfo.finalLevelModifiedInternalOrder.Code;
                    internalorder.ModifiedBy = User.Identity.Name;
                    internalorder.ModifiedDate = DateTime.Now;
                    internalOrderService.Update(internalorder);
                }

                ApproveWorkflow("IO", approveInfo.requestNumber, approveInfo.status, approveInfo.comments);
                var internalorderReq = internalOrderService.GetAll().Where(A => A.RequestNumber == approveInfo.requestNumber).SingleOrDefault();
                internalorderReq.Comments = approveInfo.comments;
                internalOrderService.Update(internalorderReq);
                response = Request.CreateResponse(HttpStatusCode.OK, "Success");
                tes.Complete();
            }

            return response;
        }

        [HttpGet]
        [Route("api/MDMAPI/GetInternalOrderByRequestNumber/{requestNumber}")]
        public HttpResponseMessage GetInternalOrderByRequestNumber(string requestNumber)
        {
            HttpResponseMessage response = null;
            try
            {
                var allowSubmit = workFlowService.IsAllowtoSubmit("IO", User.Identity.GetUserId(), requestNumber);
                var internalorder = internalOrderService.GetAll().Where(MS => MS.RequestNumber == requestNumber).ToList();
                internalorder.ForEach(p => p.IsAllowtoSubmit = allowSubmit);
                if (IsLastLevelApproval("IO", requestNumber))
                {
                    internalorder.ForEach(c => c.Level = false);
                }
                else
                {
                    internalorder.ForEach(c => c.Level = true);
                }
                response = Request.CreateResponse(HttpStatusCode.OK, internalorder);
                return response;
            }
            catch (Exception Ex)
            {
                return null;
            }
        }

        [HttpGet]
        [Route("api/MDMAPI/isExistingInternalOrderCode/{internalordercode}/{id}")]
        public bool isExistingInternalOrderCode(string internalordercode, int id)
        {
            var internalOrderList = new List<InternalOrder>();
            if (id == 0)
            {
                internalOrderList = internalOrderService.GetAll().Where(IO => IO.Code == internalordercode).ToList();
            }
            else
            {
                internalOrderList = internalOrderService.GetAll().Where(IO => IO.Code == internalordercode && IO.Id != id).ToList();
            }

            //var currencyCode = currencyService.GetAll().Where(c => c.Code == currencycode).SingleOrDefault();
            bool isexists = false;
            if (internalOrderList.Count > 0)
            {
                isexists = true;
            }
            return isexists;
        }
        #endregion

        #region//Vendor Transaction


        [HttpGet]
        public HttpResponseMessage GetVendorTransaction()
        {
            try
            {
                HttpResponseMessage response = null;
                var vendordata = vendorTransactionService.GetDraftData(Helper.GetMasterCode(Masters.Vendor), User.Identity.Name);
                //response = new HttpResponseMessage()
                //{
                //    Content = new JsonContent(vendordata)
                //};
                response = Request.CreateResponse(HttpStatusCode.OK, vendordata);
                return response;
            }
            catch (Exception Ex)
            {
                string error;
                error = Ex.Message;
                if (Ex.InnerException != null)
                {
                    error = error + "|";
                    error = Ex.InnerException.Message;
                    if (Ex.InnerException.InnerException != null)
                    {
                        error = error + "|";
                        error = error + Ex.InnerException.InnerException.Message;
                    }

                }
                return Request.CreateResponse(HttpStatusCode.ExpectationFailed, error);
            }
        }


        public class JsonContent : HttpContent
        {

            private readonly MemoryStream _Stream = new MemoryStream();
            public JsonContent(object value)
            {

                Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                var jw = new Newtonsoft.Json.JsonTextWriter(new StreamWriter(_Stream));
                jw.Formatting = Newtonsoft.Json.Formatting.Indented;
                var serializer = new Newtonsoft.Json.JsonSerializer();
                serializer.Serialize(jw, value);
                jw.Flush();
                _Stream.Position = 0;

            }
            protected override Task SerializeToStreamAsync(Stream stream, TransportContext context)
            {
                return _Stream.CopyToAsync(stream);
            }

            protected override bool TryComputeLength(out long length)
            {
                length = _Stream.Length;
                return true;
            }
        }




        [HttpGet]
        [Route("api/MDMAPI/GetVTByRequestNumber/{requestNumber}")]
        public HttpResponseMessage GetVTByRequestNumber(string requestNumber)
        {
            HttpResponseMessage response = null;
            try
            {
                VendorData vendorData = new VendorData();
                var allowSubmit = workFlowService.IsAllowtoSubmit(Helper.GetMasterCode(Masters.Vendor), User.Identity.GetUserId(), requestNumber);
                var vendor = vendorTransactionService.GetVTByRequestNumber(requestNumber, allowSubmit, IsLastLevelApproval(Helper.GetMasterCode(Masters.Vendor), requestNumber));
                response = Request.CreateResponse(HttpStatusCode.OK, vendor);
                return response;
            }
            catch (Exception Ex)
            {
                return null;
            }
        }
        [HttpPost]
        [Route("api/MDMAPI/AddVendorTransaction/{IsSubmit}")]
        public HttpResponseMessage AddVendorTransaction(VendorData vendor, bool IsSubmit)
        {

            HttpResponseMessage response = null;
            try
            {

                if (!IsSubmit)
                {
                    ModelState.Remove("vendor.vendor.AditionalWorkflowId");
                }
                ModelState.Remove("vendor.vendor.PANValidFromDate");
                ModelState.Remove("vendor.vendor.DOB");
                if (!string.IsNullOrWhiteSpace(vendor.vendor.DateofBirth))
                {
                    vendor.vendor.DOB = DateTime.Parse(vendor.vendor.DateofBirth, new CultureInfo("en-CA"));
                }
                if (!string.IsNullOrWhiteSpace(vendor.vendor.PANValidFrom))
                {
                    vendor.vendor.PANValidFromDate = DateTime.Parse(vendor.vendor.PANValidFrom, new CultureInfo("en-CA"));
                }
                if (vendor.WHTTaxforVendor != null)
                {
                    foreach (var whtTax in vendor.WHTTaxforVendor)
                    {
                        if (!string.IsNullOrWhiteSpace(whtTax.ExemptionTo))
                        {
                            whtTax.exemptionToDate = DateTime.Parse(whtTax.ExemptionTo, new CultureInfo("en-CA"));
                        }
                        if (!string.IsNullOrWhiteSpace(whtTax.ExemptionFrom))
                        {
                            whtTax.exemptionFromDate = DateTime.Parse(whtTax.ExemptionFrom, new CultureInfo("en-CA"));
                        }
                        if (vendor.vendor.Id != 0)
                        {
                            whtTax.VendorTransactionId = vendor.vendor.Id;
                        }
                        ModelState.Remove("whtTax.country");
                    }
                }
                //if (vendor.vendor.Id != 0)
                //{
                //    vendor.paymentTransaction = vendor.paymentTransaction.Where(F => F.VendorTransactionId == vendor.vendor.Id).ToList();
                //    //if (vendor.paymentTransaction != null)
                //    //{
                //    //    foreach (var paymentTransaction in vendor.paymentTransaction)
                //    //    {
                //    //        if (paymentTransaction.Id == 0)
                //    //        {
                //    //            paymentTransaction.VendorTransactionId = vendor.vendor.Id;
                //    //        }
                //    //    }
                //    //}
                //}
                //if (vendor.paymentTransaction != null)
                //{
                //    foreach (var paymentTransaction in vendor.paymentTransaction)
                //    {
                //ModelState.Remove("paymentTransaction.countryName");
                //    }
                //}
                ModelState.Remove("whtTax.level");
                //ModelState.Remove("vendor.paymentTransaction.countryName");
                //ModelState.Remove("vendor.paymentTransaction[0].countryName");
                //vendor.vendor.PaymentTransactions = null;
                //vendor.vendor.WHTTaxes = null;
                if (!ModelState.IsValid)
                {
                    response = Request.CreateResponse(HttpStatusCode.InternalServerError, BadRequest(ModelState));
                    return response;
                }
                using (var t = new TransactionScope())
                {

                    if (vendor.vendor.Id == 0)
                    {
                        // This Area Need to Insert in BULK Insert Method                        
                        vendor.vendor.CreatedBy = User.Identity.Name;
                        vendor.vendor.CreatedOn = DateTime.Now;
                        vendor.vendor.RequestNumber = Helper.GetMasterCode(Masters.Vendor) + Helper.GetRandomNumber();
                        vendorTransactionService.Insert(vendor.vendor);
                    }
                    else
                    {
                        vendor.vendor.ModifiedBy = User.Identity.Name;
                        vendor.vendor.ModifiedOn = DateTime.Now;
                        vendorTransactionService.Update(vendor.vendor);

                    }
                    if (vendor.paymentTransaction != null)
                    {
                        foreach (var paymentTransaction in vendor.paymentTransaction)
                        {
                            if (paymentTransaction.Id == 0)
                            {
                                paymentTransaction.VendorTransactionId = vendor.vendor.Id;
                                paymentTransaction.CreatedBy = User.Identity.Name;
                                paymentTransaction.CreatedOn = DateTime.Now;
                                paymentTransactionService.Insert(paymentTransaction);
                            }
                            else
                            {
                                paymentTransaction.VendorTransactionId = vendor.vendor.Id;
                                paymentTransaction.ModifiedBy = User.Identity.Name;
                                paymentTransaction.ModifiedOn = DateTime.Now;
                                paymentTransactionService.Update(paymentTransaction);
                            }
                        }
                    }
                    if (vendor.WHTTaxforVendor != null)
                    {
                        foreach (var WHTTaxforVendor in vendor.WHTTaxforVendor)
                        {
                            if (WHTTaxforVendor.Id == 0)
                            {
                                WHTTaxforVendor.VendorTransactionId = vendor.vendor.Id;
                                WHTTaxforVendor.CreatedBy = User.Identity.Name;
                                WHTTaxforVendor.CreatedOn = DateTime.Now;
                                whtTaxforVendorService.Insert(WHTTaxforVendor);
                            }
                            else
                            {
                                WHTTaxforVendor.VendorTransactionId = vendor.vendor.Id;
                                WHTTaxforVendor.ModifiedBy = User.Identity.Name;
                                WHTTaxforVendor.ModifiedOn = DateTime.Now;
                                whtTaxforVendorService.Update(WHTTaxforVendor);
                            }
                        }
                    }
                    if (IsSubmit)
                    {
                        CreateWorkflow(Helper.GetMasterCode(Masters.Vendor), vendor.vendor.RequestNumber, vendor.vendor.Comments, vendor.vendor.AditionalWorkflowId);
                    }
                    t.Complete();
                }
                response = Request.CreateResponse(HttpStatusCode.OK, "Successfully Inserted");
                return response;
            }
            //catch (Exception Ex)
            //{
            //    return null;
            //}
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting  
                        // the current instance as InnerException  
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
        }
        [HttpGet]
        public HttpResponseMessage LoadVendorTransactionDropdownList()
        {
            try
            {
                HttpResponseMessage response = null;
                var vendorTransaction = vendorTransactionService.getDropdownData(Helper.GetMasterCode(Masters.Vendor));
                vendorTransaction.IsWorflowAssigned = workFlowService.GetID(Helper.GetMasterCode(Masters.Vendor)) > 0 ? true : false;
                response = Request.CreateResponse(HttpStatusCode.OK, vendorTransaction);
                return response;
            }
            catch (Exception Ex)
            {
                return null;
            }
        }


        public HttpResponseMessage ApproveVendor(ApproveInfo approveInfo)
        {
            HttpResponseMessage response = null;
            using (var trans = new TransactionScope())
            {

                ApproveWorkflow("VT", approveInfo.requestNumber, approveInfo.status, approveInfo.comments);
                #region "Code to insert Region Comments"
                var _vendor = vendorTransactionService.GetAll().Where(A => A.RequestNumber == approveInfo.requestNumber).SingleOrDefault();
                _vendor.Comments = approveInfo.comments;
                _vendor.ModifiedBy = User.Identity.GetUserId();
                _vendor.ModifiedOn = DateTime.Now;
                vendorTransactionService.Update(_vendor);
                #endregion
                response = Request.CreateResponse(HttpStatusCode.OK, "Success");
                trans.Complete();
            }


            return response;
        }


        [HttpPost]
        [Route("api/MDMAPI/UpdateVendorPaymenttransaction/{paymentid}")]
        public HttpResponseMessage UpdateVendorPaymenttransaction(PaymentTransaction paymentTransaction, int paymentid)
        {

            HttpResponseMessage response = null;
            try
            {
                paymentTransaction.IsDelete = true;
                paymentTransaction.ModifiedBy = User.Identity.Name;
                paymentTransaction.ModifiedOn = DateTime.Now;
                paymentTransactionService.Update(paymentTransaction);

                response = Request.CreateResponse(HttpStatusCode.OK, "Successfully Deleted");
                return response;
            }
            catch
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, "Successfully Deleted");
                return response;
            }
        }

        [HttpPost]
        [Route("api/MDMAPI/DeleteVendorWHT/{whtid}")]
        public HttpResponseMessage DeleteVendorWHT(WHTTaxforVendorTransaction vendorWHTTax, int whtid)
        {

            HttpResponseMessage response = null;
            try
            {
                vendorWHTTax.IsDelete = true;
                vendorWHTTax.ModifiedBy = User.Identity.Name;
                vendorWHTTax.ModifiedOn = DateTime.Now;
                whtTaxforVendorService.Update(vendorWHTTax);

                response = Request.CreateResponse(HttpStatusCode.OK, "Successfully Deleted");
                return response;
            }
            catch
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, "Successfully Deleted");
                return response;
            }
        }

        #endregion

        #region//GeneralLedger

        [HttpGet]
        public HttpResponseMessage GetGeneralLedger()
        {
            try
            {
                HttpResponseMessage response = null;
                response = Request.CreateResponse(HttpStatusCode.OK, generalledgerService.GetDraftData(Helper.GetMasterCode(Masters.GeneralLedger), User.Identity.Name));
                return response;
            }
            catch (Exception Ex)
            {
                return null;
            }
        }
        //private bool IsLastLevelApproval(string MasterCode, string requestNumber)
        //{
        //    try
        //    {
        //        return generalledgerService.IsLastLevelApproval(workFlowStatusService.GetID(MasterCode, requestNumber), MasterCode, requestNumber);
        //    }
        //    catch (Exception Ex)
        //    {
        //        return false;
        //    }
        //}
        [HttpGet]
        [Route("api/MDMAPI/GetGLByRequestNumber/{requestNumber}")]
        public HttpResponseMessage GetGLByRequestNumber(string requestNumber)
        {
            HttpResponseMessage response = null;
            try
            {
                var allowSubmit = workFlowService.IsAllowtoSubmit(Helper.GetMasterCode(Masters.GeneralLedger), User.Identity.GetUserId(), requestNumber);
                var GeneralLedger = generalledgerService.GetGLByRequestNumber(requestNumber, allowSubmit, IsLastLevelApproval(Helper.GetMasterCode(Masters.GeneralLedger), requestNumber), Helper.GetMasterCode(Masters.GeneralLedger));
                response = Request.CreateResponse(HttpStatusCode.OK, GeneralLedger);
                return response;
            }
            catch (Exception Ex)
            {
                return null;
            }
        }

        [HttpGet]
        [Route("api/MDMAPI/GetCompanyCountry/{companycode}")]
        public HttpResponseMessage GetCompanyCountry(int companycode)
        {
            HttpResponseMessage response = null;
            try
            {

                var companyCountry = generalledgerService.GetCompanyCountry(companycode);
                response = Request.CreateResponse(HttpStatusCode.OK, companyCountry);
                return response;
            }
            catch (Exception Ex)
            {
                return null;
            }
        }
        [HttpPost]
        [Route("api/MDMAPI/AddGeneralLedger/{IsSubmit}")]
        public HttpResponseMessage AddGeneralLedger(GeneralLedger GeneralLedger, bool IsSubmit)
        {

            HttpResponseMessage response = null;
            try
            {
                if (!string.IsNullOrWhiteSpace(GeneralLedger.strLastInterestCalKeyDate))
                {
                    GeneralLedger.LastInterestCalKeyDate = DateTime.Parse(GeneralLedger.strLastInterestCalKeyDate, new CultureInfo("en-CA"));
                }
                if (!string.IsNullOrWhiteSpace(GeneralLedger.strLastInterestCalDateRun))
                {
                    GeneralLedger.LastInterestCalDateRun = DateTime.Parse(GeneralLedger.strLastInterestCalDateRun, new CultureInfo("en-CA"));
                }
                if (!IsSubmit)
                {
                    ModelState.Remove("GeneralLedger.AditionalWorkflowId");
                }
                ModelState.Remove("GeneralLedger.lastInterestCalKeyDate");
                ModelState.Remove("GeneralLedger.lastInterestCalDateRun");
                if (!ModelState.IsValid)
                {
                    response = Request.CreateResponse(HttpStatusCode.InternalServerError, BadRequest(ModelState));
                    return response;
                }
                if (GeneralLedger.AccountNumber != null)
                {
                    if (generalledgerService.ExistsAccountNumber(GeneralLedger.AccountNumber, GeneralLedger.Id))
                    {
                        response = Request.CreateResponse(HttpStatusCode.Ambiguous, "GL Account number is already exists.");
                        return response;
                    }
                }
                GeneralLedger.IsDelete = false;
                using (var t = new TransactionScope())
                {
                    if (GeneralLedger.Id == 0)
                    {
                        // This Area Need to Insert in BULK Insert Method                    
                        GeneralLedger.CreatedBy = User.Identity.Name;
                        GeneralLedger.CreatedOn = DateTime.Now;
                        GeneralLedger.RequestNumber = Helper.GetMasterCode(Masters.GeneralLedger) + Helper.GetRandomNumber();
                        generalledgerService.Insert(GeneralLedger);

                    }
                    else
                    {
                        GeneralLedger.Modifiedby = User.Identity.Name;
                        GeneralLedger.ModifiedOn = DateTime.Now;
                        generalledgerService.Update(GeneralLedger);
                    }
                    if (IsSubmit)
                    {
                        CreateWorkflow(Helper.GetMasterCode(Masters.GeneralLedger), GeneralLedger.RequestNumber, GeneralLedger.Comments, GeneralLedger.AditionalWorkflowId);
                    }
                    t.Complete();
                }
                response = Request.CreateResponse(HttpStatusCode.OK, "Successfully Inserted");
                return response;
            }
            //catch (Exception Ex)
            //{
            //    return null;
            //}
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting  
                        // the current instance as InnerException  
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
        }

        [HttpGet]
        public HttpResponseMessage LoadGeneralLedgerDropdowns(int Id)
        {
            try
            {
                HttpResponseMessage response = null;
                var GeneralLedger = generalledgerService.getDropdownData(Helper.GetMasterCode(Masters.GeneralLedger), Id);
                GeneralLedger.IsWorflowAssigned = workFlowService.GetID(Helper.GetMasterCode(Masters.GeneralLedger)) > 0 ? true : false;
                response = Request.CreateResponse(HttpStatusCode.OK, GeneralLedger);
                return response;
            }
            catch (Exception Ex)
            {
                return null;
            }
        }

        [HttpPost]
        public HttpResponseMessage ApproveGeneralLedger(ApproveInfo approveInfo)
        {
            HttpResponseMessage response = null;
            using (var tes = new TransactionScope())
            {
                if (approveInfo.finalLevedGeneralLedger != null)
                {
                    var generalledgerReq = approveInfo.finalLevedGeneralLedger;
                    generalledgerReq.Comments = approveInfo.comments;
                    generalledgerService.Update(generalledgerReq);
                    ApproveWorkflow(Helper.GetMasterCode(Masters.GeneralLedger), approveInfo.requestNumber, approveInfo.status, approveInfo.comments);
                }
                response = Request.CreateResponse(HttpStatusCode.OK, "Success");
                tes.Complete();
            }

            return response;
        }
        [HttpGet]
        [Route("api/MDMAPI/IsExistingGLCode/{GLcode}/{RequestNumber}")]
        public bool IsExistingGLCode(string GLcode, int RequestNumber)
        {

            return generalledgerService.ExistsAccountNumber(GLcode, RequestNumber);//.Where(cc => cc.AccountNumber == GLcode).SingleOrDefault();
            //bool isexists = false;
            //if (GLcodedata != null)
            //{
            //    isexists = true;
            //}
            //return isexists;

        }

        //#region code to know existing GeneralLedgercode
        //[HttpGet]
        //[Route("api/MDMAPI/IsExistingCode/{GeneralLedgercode}")]
        //public bool IsExistingCode(string GeneralLedgercode, string master)
        //{

        //    var GeneralLedgerdata = generalledgerService.GetAll().Where(cc => cc. == GeneralLedgercode).SingleOrDefault();
        //    bool isexists = false;
        //    if (GeneralLedgerdata != null)
        //    {
        //        isexists = true;
        //    }
        //    return isexists;

        //}
        //#endregion
        #endregion

        #region//ExchangeRate

        [HttpGet]
        public HttpResponseMessage GetExchangeRateTransaction()
        {
            try
            {
                HttpResponseMessage response = null;
                response = Request.CreateResponse(HttpStatusCode.OK, exchagerateTransactionService.GetDraftData(Helper.GetMasterCode(Masters.ExchangeRate), User.Identity.Name));
                return response;
            }
            catch (Exception Ex)
            {
                return null;
            }
        }

        [HttpGet]
        [Route("api/MDMAPI/GetExchangeRate/{requestNumber}")]
        public HttpResponseMessage GetExchangeRate(string requestNumber)
        {
            try
            {
                HttpResponseMessage response = null;
                var exchangeRate = exchagerateService.GetDraftData(requestNumber);
                exchangeRate.IsWorflowAssigned = workFlowService.GetID(Helper.GetMasterCode(Masters.ExchangeRate)) > 0 ? true : false;
                response = Request.CreateResponse(HttpStatusCode.OK, exchangeRate);
                return response;
            }
            catch (Exception Ex)
            {
                return null;
            }
        }
        //[HttpGet]
        //[Route("api/MDMAPI/GetERByRequestNumber/{requestNumber}")]
        //public HttpResponseMessage GetERByRequestNumber(string requestNumber)
        //{
        //    HttpResponseMessage response = null;
        //    try
        //    {
        //        var allowSubmit = workFlowService.IsAllowtoSubmit(Helper.GetMasterCode(Masters.ExchangeRate), User.Identity.GetUserId(), requestNumber);
        //        var ExchangeRate = exchagerateService.GetERByRequestNumber(requestNumber, allowSubmit, IsLastLevelApproval(Helper.GetMasterCode(Masters.ExchangeRate), requestNumber), Helper.GetMasterCode(Masters.ExchangeRate));
        //        response = Request.CreateResponse(HttpStatusCode.OK, ExchangeRate);
        //        return response;
        //    }
        //    catch (Exception Ex)
        //    {
        //        return null;
        //    }
        //}

        [HttpGet]
        [Route("api/MDMAPI/GetERTransactionByRequestNumber/{requestNumber}")]
        public HttpResponseMessage GetERTransactionByRequestNumber(string requestNumber)
        {
            HttpResponseMessage response = null;
            try
            {
                ExchangeRateIsAllowtoSubmit obj = new ExchangeRateIsAllowtoSubmit();
                obj.IsAllowtoSubmit = workFlowService.IsAllowtoSubmit(Helper.GetMasterCode(Masters.ExchangeRate), User.Identity.GetUserId(), requestNumber);
                obj.ExchangeRateTra = exchagerateTransactionService.GetERTransactionByRequestNumber(requestNumber, obj.IsAllowtoSubmit, IsLastLevelApproval(Helper.GetMasterCode(Masters.ExchangeRate), requestNumber), Helper.GetMasterCode(Masters.ExchangeRate));
                if (IsLastLevelApproval("ER", requestNumber))
                {
                    obj.ExchangeRateTra.Level = true;
                    //ExchangeRateTra.ForEach(c => c.Level = true);
                }
                else
                {
                    obj.ExchangeRateTra.Level = false;
                    // ExchangeRateTra.ForEach(c => c.Level = false);
                }

                response = Request.CreateResponse(HttpStatusCode.OK, obj);
                return response;
            }
            catch (Exception Ex)
            {
                return null;
            }
        }


        [HttpPost]
        [Route("api/MDMAPI/AddExchangeRate/{IsSubmit}")]
        public HttpResponseMessage AddExchangeRate(ExchangeRate ExchangeRate, bool IsSubmit)
        {

            HttpResponseMessage response = null;
            try
            {
                if (!string.IsNullOrWhiteSpace(ExchangeRate.strExcchangerateEffectivedate))
                {
                    ExchangeRate.ExcchangerateEffectivedate = DateTime.Parse(ExchangeRate.strExcchangerateEffectivedate, new CultureInfo("en-CA"));
                }

                if (!IsSubmit)
                {
                    ModelState.Remove("ExchangeRate.AditionalWorkflowId");
                }
                ModelState.Remove("ExchangeRate.excchangerateEffectivedate");
                if (!ModelState.IsValid)
                {
                    response = Request.CreateResponse(HttpStatusCode.InternalServerError, BadRequest(ModelState));
                    return response;
                }
                ExchangeRate.IsDelete = false;
                using (var t = new TransactionScope())
                {
                    if (ExchangeRate.Id == 0)
                    {
                        // This Area Need to Insert in BULK Insert Method                    
                        ExchangeRate.CreatedBy = User.Identity.Name;
                        ExchangeRate.CreatedDate = DateTime.Now;
                        ExchangeRate.RequestNumber = Helper.GetMasterCode(Masters.ExchangeRate) + Helper.GetRandomNumber();
                        exchagerateService.Insert(ExchangeRate);

                    }
                    else
                    {
                        ExchangeRate.ModifiedBy = User.Identity.Name;
                        ExchangeRate.ModifiedDate = DateTime.Now;
                        exchagerateService.Update(ExchangeRate);
                    }
                    if (IsSubmit)
                    {
                        CreateWorkflow(Helper.GetMasterCode(Masters.ExchangeRate), ExchangeRate.RequestNumber, ExchangeRate.Comments, ExchangeRate.AditionalWorkflowId);
                    }
                    t.Complete();
                }
                response = Request.CreateResponse(HttpStatusCode.OK, "Successfully Inserted");
                return response;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting  
                        // the current instance as InnerException  
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
        }

        [HttpPost]
        [Route("api/MDMAPI/SaveExchangeRate/{ExchangeRatecomments}/{IsSubmit}")]
        public HttpResponseMessage SaveExchangeRate(List<ExchangeRate> exchangeRates, string ExchangeRatecomments, bool IsSubmit)
        {
            TimeSpan ts = new TimeSpan(12, 00, 00);
            HttpResponseMessage response = null;

            using (var t = new TransactionScope())
            {
                if (exchangeRates.Count > 0)
                {
                    if (!string.IsNullOrWhiteSpace(ExchangeRatecomments))
                    {
                        ExchangeRateTransaction et = exchagerateTransactionService.GetAll().FirstOrDefault(F => F.RequestNumber == exchangeRates[0].RequestNumber);
                        et.Comments = ExchangeRatecomments;
                        exchagerateTransactionService.Update(et);
                    }
                    foreach (ExchangeRate ExchangeRate in exchangeRates)
                    {

                        if (ExchangeRate.Id == 0)
                        {

                        }
                        else
                        {
                            //if (ExchangeRate.ExcchangerateEffectivedate != null)
                            //{
                            //    DateTime dt = Convert.ToDateTime(ExchangeRate.ExcchangerateEffectivedate).AddDays(1);
                            //    ExchangeRate.ExcchangerateEffectivedate = dt;
                            //}
                            if (ExchangeRate.ExcchangerateEffectivedate != null)
                            {
                                
                                DateTime dt = Convert.ToDateTime(ExchangeRate.ExcchangerateEffectivedate).Date + ts;
                                ExchangeRate.ExcchangerateEffectivedate = dt;
                            }
                            ExchangeRate.ModifiedBy = User.Identity.Name;
                            ExchangeRate.ModifiedDate = DateTime.Now;
                            ExchangeRate.ExchangeRateValue = Convert.ToDouble(String.Format("{0:0.00000}", ExchangeRate.ExchangeRateValue));
                            exchagerateService.Update(ExchangeRate);
                        }



                    }

                    //if (!string.IsNullOrWhiteSpace(ExchangeRate.strExcchangerateEffectivedate))
                    //{
                    //    ExchangeRate.ExcchangerateEffectivedate = DateTime.Parse(ExchangeRate.strExcchangerateEffectivedate, new CultureInfo("en-CA"));
                    //}

                    //if (!IsSubmit)
                    //{
                    //    ModelState.Remove("ExchangeRate.AditionalWorkflowId");
                    //}
                    //ModelState.Remove("ExchangeRate.excchangerateEffectivedate");
                    //if (!ModelState.IsValid)
                    //{
                    //    response = Request.CreateResponse(HttpStatusCode.InternalServerError, BadRequest(ModelState));
                    //    return response;
                    //}
                    //ExchangeRate.IsDelete = false;
                    //using (var t = new TransactionScope())
                    //{
                    //    if (ExchangeRate.Id == 0)
                    //    {
                    //        // This Area Need to Insert in BULK Insert Method                    
                    //        ExchangeRate.CreatedBy = User.Identity.Name;
                    //        ExchangeRate.CreatedDate = DateTime.Now;
                    //        ExchangeRate.RequestNumber = Helper.GetMasterCode(Masters.ExchangeRate) + Helper.GetRandomNumber();
                    //        exchagerateService.Insert(ExchangeRate);

                    //    }
                    //    else
                    //    {
                    //        ExchangeRate.ModifiedBy = User.Identity.Name;
                    //        ExchangeRate.ModifiedDate = DateTime.Now;
                    //        exchagerateService.Update(ExchangeRate);
                    //    }
                    //    if (IsSubmit)
                    //    {
                    //        CreateWorkflow(Helper.GetMasterCode(Masters.ExchangeRate), ExchangeRate.RequestNumber, ExchangeRate.Comments, ExchangeRate.AditionalWorkflowId);
                    //    }
                    //    t.Complete();
                    //}
                    if (IsSubmit)
                    {
                        CreateWorkflow(Helper.GetMasterCode(Masters.ExchangeRate), exchangeRates[0].RequestNumber, ExchangeRatecomments);
                    }
                }
                t.Complete();
                response = Request.CreateResponse(HttpStatusCode.OK, "Successfully Inserted");
                return response;
            }

        }


        [HttpPost]
        [Route("api/MDMAPI/SubmitExchangeRate/{IsSubmit}")]
        public HttpResponseMessage SubmitExchangeRate(ExchangeRateTransaction ExchangeRateTransaction, bool IsSubmit)
        {
            TimeSpan ts = new TimeSpan(12, 00, 00);
            HttpResponseMessage response = null;
            try
            {
                if (!ModelState.IsValid)
                {
                    response = Request.CreateResponse(HttpStatusCode.InternalServerError, BadRequest(ModelState));
                    return response;
                }
                ExchangeRateTransaction.IsDelete = false;
                using (var t = new TransactionScope())
                {
                    if (ExchangeRateTransaction.Id == 0)
                    {
                        // This Area Need to Insert in BULK Insert Method                    
                        ExchangeRateTransaction.CreatedBy = User.Identity.Name;
                        ExchangeRateTransaction.CreatedDate = DateTime.Now;

                        exchagerateTransactionService.Insert(ExchangeRateTransaction);

                    }
                    else
                    {

                        ExchangeRateTransaction.ModifiedBy = User.Identity.Name;
                        ExchangeRateTransaction.ModifiedDate = DateTime.Now;
                        exchagerateTransactionService.Update(ExchangeRateTransaction);
                    }
                    if (IsSubmit)
                    {
                        CreateWorkflow(Helper.GetMasterCode(Masters.ExchangeRate), ExchangeRateTransaction.RequestNumber, ExchangeRateTransaction.Comments);
                    }
                    t.Complete();
                }
                response = Request.CreateResponse(HttpStatusCode.OK, "Successfully Inserted");
                return response;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting  
                        // the current instance as InnerException  
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
        }

        [HttpGet]
        public HttpResponseMessage LoadExchangeRateDropdowns(int Id)
        {
            try
            {
                HttpResponseMessage response = null;
                var ExchangeRate = exchagerateService.getDropdownData(Helper.GetMasterCode(Masters.ExchangeRate), Id);
                ExchangeRate.IsWorflowAssigned = workFlowService.GetID(Helper.GetMasterCode(Masters.ExchangeRate)) > 0 ? true : false;
                response = Request.CreateResponse(HttpStatusCode.OK, ExchangeRate);
                return response;
            }
            catch (Exception Ex)
            {
                return null;
            }
        }


        [HttpPost]
        public HttpResponseMessage ApproveExchangeRateTransaction(ApproveInfo approveInfo)
        {
            TimeSpan ts = new TimeSpan(12, 00, 00);
            HttpResponseMessage response = null;
            using (var tes = new TransactionScope())
            {

                if (approveInfo.finalLevedExchangeRateTransaction != null)
                {
                    var ExchangeRateReq = approveInfo.finalLevedExchangeRateTransaction.objExchangeRateTransaction;
                    if (approveInfo.finalLevedExchangeRateTransaction.ExchangeRates != null)
                    {
                        var exchangeRates = approveInfo.finalLevedExchangeRateTransaction.ExchangeRates;
                        if (exchangeRates.Count > 0)
                        {
                            foreach (ExchangeRate ExchangeRate in exchangeRates)
                            {

                                if (ExchangeRate.Id == 0)
                                {

                                }
                                else
                                {
                                    //if (ExchangeRate.ExcchangerateEffectivedate != null)
                                    //{
                                    //    DateTime dt = Convert.ToDateTime(ExchangeRate.ExcchangerateEffectivedate).AddDays(1);
                                    //    ExchangeRate.ExcchangerateEffectivedate = dt;
                                    //}
                                    if (ExchangeRate.ExcchangerateEffectivedate != null)
                                    {

                                        DateTime dt = Convert.ToDateTime(ExchangeRate.ExcchangerateEffectivedate).Date + ts;
                                        ExchangeRate.ExcchangerateEffectivedate = dt;
                                    }
                                    ExchangeRate.ModifiedBy = User.Identity.Name;
                                    ExchangeRate.ModifiedDate = DateTime.Now;
                                    ExchangeRate.ExchangeRateValue = Convert.ToDouble(String.Format("{0:0.00000}", ExchangeRate.ExchangeRateValue));
                                    exchagerateService.Update(ExchangeRate);
                                }



                            }
                        }
                    }


                    var ExchangeRateTransactionReq = approveInfo.finalLevedExchangeRateTransaction.objExchangeRateTransaction;
                    ExchangeRateTransactionReq.Comments = approveInfo.comments;
                    //ExchangeRateReq.m //kiran
                    exchagerateTransactionService.Update(ExchangeRateTransactionReq);
                    ApproveWorkflow(Helper.GetMasterCode(Masters.ExchangeRate), approveInfo.requestNumber, approveInfo.status, approveInfo.comments);
                }
                response = Request.CreateResponse(HttpStatusCode.OK, "Success");
                tes.Complete();
            }

            return response;
        }

        [HttpPost]
        public HttpResponseMessage SaveFiles()
        {
            string Message, fileName, actualFileName;
            Message = fileName = actualFileName = string.Empty;
            bool flag = false;
            HttpResponseMessage response = null;
            if (HttpContext.Current.Request.Files != null)
            {
                var file = HttpContext.Current.Request.Files[0];
                actualFileName = file.FileName;
                fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                int size = file.ContentLength;
                int insertedCount = 0;
                int NotinsertedCount = 0;
                cvsdata obj = new cvsdata();

                try
                {

                    IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(file.InputStream);

                    //4. DataSet - Create column names from first row
                    excelReader.IsFirstRowAsColumnNames = true;

                    DataSet result = excelReader.AsDataSet();


                    if (result != null)
                    {
                        DataTable filteredRows = result.Tables[0].Rows.Cast<DataRow>()
                   .Where(row => !row.ItemArray.All(field => field is System.DBNull))
                   .CopyToDataTable();
                        //foreach (DataTable table in result.Tables)
                        //{

                        string strRequestNumber = Helper.GetMasterCode(Masters.ExchangeRate) + Helper.GetRandomNumber();
                        ExchangeRateTransaction objExchangeRateTransaction = new ExchangeRateTransaction();
                        objExchangeRateTransaction.CreatedBy = User.Identity.Name;
                        objExchangeRateTransaction.CreatedDate = DateTime.Now;
                        objExchangeRateTransaction.RequestNumber = strRequestNumber;
                        exchagerateTransactionService.Insert(objExchangeRateTransaction);


                        foreach (DataRow row in filteredRows.Rows)
                        {
                            DateTime dt = new DateTime();
                            double RateValue = 00;
                            if (row.ItemArray[4] != null)
                            {
                                string strdt = Convert.ToString(row.ItemArray[4]);
                                if (!string.IsNullOrWhiteSpace(strdt) && strdt.Length == 8)
                                {
                                    int dd = Convert.ToInt32(strdt.Substring(0, 2));
                                    int mm = Convert.ToInt32(strdt.Substring(2, 2));
                                    int yy = Convert.ToInt32(strdt.Substring(4, 4));
                                    dt = new DateTime(yy, mm, dd);
                                    //dt.AddDays(1);
                                }
                                if (row.ItemArray[5] != null)
                                {
                                    //objExchangeRate.ExchangeRateValue = Convert.ToDouble(row.ItemArray[5]);
                                    RateValue = Convert.ToDouble(String.Format("{0:0.00000}", Convert.ToDouble(row.ItemArray[5])));
                                }
                            }
                            var objExchangeRate = exchagerateService.IsExist(Convert.ToString(row.ItemArray[0]), Convert.ToString(row.ItemArray[1]), Convert.ToString(row.ItemArray[2]), Convert.ToString(row.ItemArray[3]), dt, RateValue);
                            if (objExchangeRate != null)
                            {
                                if (row.ItemArray[4] != null)
                                {
                                    objExchangeRate.ExcchangerateEffectivedate = dt;
                                }
                                if (row.ItemArray[5] != null)
                                {
                                    //objExchangeRate.ExchangeRateValue = Convert.ToDouble(row.ItemArray[5]);
                                    objExchangeRate.ExchangeRateValue = Convert.ToDouble(String.Format("{0:0.00000}", Convert.ToDouble(row.ItemArray[5])));
                                }
                                // objExchangeRate.ExcchangerateEffectivedate = Convert.ToDateTime(row.ItemArray[5]);new DateTime(2014, 1, 18)//yymmdd

                                if (row.ItemArray[6] != null)
                                {
                                    objExchangeRate.TimeValue = row.ItemArray[6].ToString();
                                }
                                else
                                {
                                    objExchangeRate.TimeValue = "120000";
                                }

                                if (objExchangeRate.DataClassId != null && objExchangeRate.FromCurrencyId != null && objExchangeRate.ToCurrencyId != null && objExchangeRate.ExchangeRateTypeId != null && objExchangeRate.ExcchangerateEffectivedate != null && objExchangeRate.ExchangeRateValue != null)
                                {
                                    if (objExchangeRate.Id == 0)
                                    {
                                        // This Area Need to Insert in BULK Insert Method                    
                                        objExchangeRate.CreatedBy = User.Identity.Name;
                                        objExchangeRate.CreatedDate = DateTime.Now;
                                        objExchangeRate.RequestNumber = strRequestNumber; //Helper.GetMasterCode(Masters.ExchangeRate) + Helper.GetRandomNumber();
                                        objExchangeRate.TimeValue = objExchangeRate.TimeValue;
                                        exchagerateService.Insert(objExchangeRate);
                                        insertedCount = insertedCount + 1;

                                    }
                                    else
                                    {
                                        objExchangeRate.ModifiedBy = User.Identity.Name;
                                        objExchangeRate.ModifiedDate = DateTime.Now;
                                        exchagerateService.Update(objExchangeRate);
                                    }
                                }
                                else
                                {
                                    InsertExchangeRateHistory(row, strRequestNumber);
                                    NotinsertedCount = NotinsertedCount + 1;
                                }


                            }
                            else
                            {
                                InsertExchangeRateHistory(row, strRequestNumber);
                                NotinsertedCount = NotinsertedCount + 1;
                            }

                        }
                        //}
                        obj.InsertedCount = insertedCount;
                        obj.NotInsertedCount = NotinsertedCount;
                        obj.RequestNumber = strRequestNumber;

                        if (obj.InsertedCount == 0)
                        {
                            objExchangeRateTransaction.IsDelete = true;
                            exchagerateTransactionService.Update(objExchangeRateTransaction);
                        }
                        response = Request.CreateResponse(HttpStatusCode.OK, obj);
                    }



                    //UploadedFile f = new UploadedFile
                    //  {
                    //      FileName = actualFileName,
                    //      FilePath = fileName,
                    //      Description = description,
                    //      FileSize = size
                    //  };
                    //using (MyDatabaseEntities dc = new MyDatabaseEntities())
                    //{
                    //    dc.UploadedFiles.Add(f);
                    //    dc.SaveChanges();
                    //    Message = "File uploaded successfully";
                    //    flag = true;
                    //}
                }
                catch (Exception)
                {
                    Message = "File upload failed! Please try again";
                }

            }
            //return new JsonResult { Data = new { Message = Message, Status = flag } };
            return response;
        }
        public void InsertExchangeRateHistory(DataRow row, string strRequestNumber)
        {
            //ExchangeRateHistory objExchangeRateHistory = new ExchangeRateHistory();
            var objExchangeRateHistory = exchagerateHistoryService.IsExist(Convert.ToString(row.ItemArray[0]), Convert.ToString(row.ItemArray[1]), Convert.ToString(row.ItemArray[2]), Convert.ToString(row.ItemArray[3]));
            if (row.ItemArray[5] != null)
            {
                //objExchangeRateHistory.ExchangeRateValue = Convert.ToDouble(row.ItemArray[5]);
                objExchangeRateHistory.ExchangeRateValue = Convert.ToDouble(String.Format("{0:0.00000}", Convert.ToDouble(row.ItemArray[5])));
            }
            // objExchangeRateHistory.ExcchangerateEffectivedate = Convert.ToDateTime(row.ItemArray[5]);new DateTime(2014, 1, 18)//yymmdd
            if (row.ItemArray[4] != null)
            {
                string strdt = Convert.ToString(row.ItemArray[4]);
                if (!string.IsNullOrWhiteSpace(strdt) && strdt.Length == 8)
                {
                    int dd = Convert.ToInt32(strdt.Substring(0, 2));
                    int mm = Convert.ToInt32(strdt.Substring(2, 2));
                    int yy = Convert.ToInt32(strdt.Substring(4, 4));
                    DateTime dt = new DateTime(yy, mm, dd);
                    objExchangeRateHistory.ExcchangerateEffectivedate = dt;
                }
            }
            if (row.ItemArray[6] != null)
            {
                objExchangeRateHistory.TimeValue = row.ItemArray[6].ToString();
            }
            else
            {
                objExchangeRateHistory.TimeValue = "120000";
            }

            if (objExchangeRateHistory.DataClassId != null && objExchangeRateHistory.FromCurrencyId != null && objExchangeRateHistory.ToCurrencyId != null && objExchangeRateHistory.ExchangeRateTypeId != null && objExchangeRateHistory.ExcchangerateEffectivedate != null && objExchangeRateHistory.ExchangeRateValue != null)
            {
                if (objExchangeRateHistory.Id == 0)
                {
                    // This Area Need to Insert in BULK Insert Method                    
                    objExchangeRateHistory.CreatedBy = User.Identity.Name;
                    objExchangeRateHistory.CreatedDate = DateTime.Now;
                    objExchangeRateHistory.RequestNumber = strRequestNumber; //Helper.GetMasterCode(Masters.ExchangeRate) + Helper.GetRandomNumber();
                    objExchangeRateHistory.TimeValue = objExchangeRateHistory.TimeValue;
                    exchagerateHistoryService.Insert(objExchangeRateHistory);

                }
                else
                {
                    objExchangeRateHistory.ModifiedBy = User.Identity.Name;
                    objExchangeRateHistory.ModifiedDate = DateTime.Now;
                    exchagerateHistoryService.Update(objExchangeRateHistory);
                }
            }
        }

        [HttpGet]
        [Route("api/MDMAPI/GetExchangeRateHistoryData/{requestNumber}")]
        public HttpResponseMessage GetExchangeRateHistoryData(string requestNumber)
        {
            HttpResponseMessage response = null;
            try
            {
                //List<ExchangeRateHistory> lstExchangeRateHistory = new List<ExchangeRateHistory>();
                var lstExchangeRateHistory = exchagerateHistoryService.GetDraftData(requestNumber);
                response = Request.CreateResponse(HttpStatusCode.OK, lstExchangeRateHistory);
                return response;
            }
            catch (Exception Ex)
            {
                return null;
            }
        }

        #endregion

        #region Hierarchy
        [HttpGet]
        public HttpResponseMessage GetHierarchy()
        {
            try
            {
                HttpResponseMessage response = null;
                response = Request.CreateResponse(HttpStatusCode.OK, hierarchyService.GetDraftData(Helper.GetMasterCode(Masters.Hierarchy), User.Identity.Name));
                return response;
            }
            catch (Exception Ex)
            {
                return null;
            }
        }
        [HttpGet]
        [Route("api/MDMAPI/GetHRByRequestNumber/{requestNumber}")]
        public HttpResponseMessage GetHRByRequestNumber(string requestNumber)
        {
            HttpResponseMessage response = null;
            try
            {
                var allowSubmit = workFlowService.IsAllowtoSubmit(Helper.GetMasterCode(Masters.Hierarchy), User.Identity.GetUserId(), requestNumber);
                var hierarchy = hierarchyService.GetHRByRequestNumber(requestNumber, allowSubmit, IsLastLevelApproval(Helper.GetMasterCode(Masters.Hierarchy), requestNumber));
                response = Request.CreateResponse(HttpStatusCode.OK, hierarchy);
                return response;
            }
            catch (Exception Ex)
            {
                return null;
            }
        }
        [HttpPost]
        [Route("api/MDMAPI/AddHierarchy/{IsSubmit}")]
        public HttpResponseMessage AddHierarchy(Hierarchy hierarchy, bool IsSubmit)
        {
            HttpResponseMessage response = null;
            try
            {
                if (!ModelState.IsValid)
                {
                    response = Request.CreateResponse(HttpStatusCode.InternalServerError, BadRequest(ModelState));
                    return response;
                }
                using (var t = new TransactionScope())
                {
                    if (hierarchy.Id == 0)
                    {
                        hierarchy.CreatedBy = User.Identity.Name;
                        hierarchy.CreatedOn = DateTime.Now;
                        hierarchy.RequestNumber = Helper.GetMasterCode(Masters.Hierarchy) + Helper.GetRandomNumber();
                        hierarchyService.Insert(hierarchy);
                    }
                    else
                    {
                        hierarchy.ModifiedBy = User.Identity.Name;
                        hierarchy.ModifiedOn = DateTime.Now;
                        hierarchyService.Update(hierarchy);
                    }
                    if (IsSubmit)
                    {
                        CreateWorkflow(Helper.GetMasterCode(Masters.Hierarchy), hierarchy.RequestNumber, hierarchy.Comments);
                    }
                    t.Complete();
                }
                response = Request.CreateResponse(HttpStatusCode.OK, "Successfully Inserted");
                return response;
            }
            catch (Exception Ex)
            {
                return null;
            }
        }
        [HttpGet]
        public HttpResponseMessage LoadHierarchyDropdownList()
        {
            try
            {
                HttpResponseMessage response = null;
                var hierarchy = hierarchyService.LoadDropDownData(Helper.GetMasterCode(Masters.Hierarchy));
                hierarchy.IsWorflowAssigned = workFlowService.GetID(Helper.GetMasterCode(Masters.Hierarchy)) > 0 ? true : false;
                response = Request.CreateResponse(HttpStatusCode.OK, hierarchy);
                return response;
            }
            catch (Exception Ex)
            {
                return null;
            }
        }
        [HttpPost]
        public HttpResponseMessage ApproveHierarchy(ApproveInfo approveInfo)
        {
            HttpResponseMessage response = null;
            using (var tes = new TransactionScope())
            {
                ApproveWorkflow("HR", approveInfo.requestNumber, approveInfo.status, approveInfo.comments);
                hierarchyService.Update(approveInfo.finalLevedModifiedDataHierarchy);
                response = Request.CreateResponse(HttpStatusCode.OK, "Success");
                tes.Complete();
            }

            return response;
        }
        [HttpGet]
        [Route("api/MDMAPI/IsExistingCostCenterHierarchy/{regionId}/{subRegionId}/{hierarchyCountryId}/{companyId}/{departmentId}/{id}")]
        public bool IsExistingCostCenterHierarchy(int regionId, int subRegionId, int hierarchyCountryId, int companyId, int departmentId, int id)
        {
            var HierarchyList = new List<Hierarchy>();
            if (id == 0)
            {
                HierarchyList = hierarchyService.GetAll().Where(c => c.RegionId == regionId && c.SubRegionId == subRegionId && c.HierarchyCountryId == hierarchyCountryId && c.CompanyId == companyId && c.DepartmentId == departmentId).ToList();
            }
            else
            {
                HierarchyList = hierarchyService.GetAll().Where(c => c.RegionId == regionId && c.SubRegionId == subRegionId && c.HierarchyCountryId == hierarchyCountryId && c.CompanyId == companyId && c.DepartmentId == departmentId && c.Id != id).ToList();
            }
            bool isexists = false;
            if (HierarchyList.Count > 0)
            {
                isexists = true;
            }
            return isexists;
        }
        #endregion
    }

}
