using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using ASL.DAL;
using ASL.DATA;
using ASL.STATIC;

namespace ASL.STATIC
{
    [Serializable]
    public class CompanySettings
    {
        public CompanySettings()
        {
            GetCompanySettings();
        }

        #region Properties

        private System.Int32 _RowID;
        [Browsable(true), DisplayName("RowID")]
        public System.Int32 RowID
        {
            get
            {
                return _RowID;
            }
            set
            {
                _RowID = value;
            }
        }

        private System.Boolean _IsUsedInventory;
        [Browsable(true), DisplayName("IsUsedInventory")]
        public System.Boolean IsUsedInventory
        {
            get
            {
                return _IsUsedInventory;
            }
            set
            {
                _IsUsedInventory = value;
            }
        }

        private System.Boolean _IsUsedOTS;
        [Browsable(true), DisplayName("IsUsedOTS")]
        public System.Boolean IsUsedOTS
        {
            get
            {
                return _IsUsedOTS;
            }
            set
            {
                _IsUsedOTS = value;
            }
        }

        private System.Boolean _IsUsedFabricControl;
        [Browsable(true), DisplayName("IsUsedFabricControl")]
        public System.Boolean IsUsedFabricControl
        {
            get
            {
                return _IsUsedFabricControl;
            }
            set
            {
                _IsUsedFabricControl = value;
            }
        }

        private System.Boolean _IsUsedWashing;
        [Browsable(true), DisplayName("IsUsedWashing")]
        public System.Boolean IsUsedWashing
        {
            get
            {
                return _IsUsedWashing;
            }
            set
            {
                _IsUsedWashing = value;
            }
        }

        private System.Boolean _IsUsedFixedAssets;
        [Browsable(true), DisplayName("IsUsedFixedAssets")]
        public System.Boolean IsUsedFixedAssets
        {
            get
            {
                return _IsUsedFixedAssets;
            }
            set
            {
                _IsUsedFixedAssets = value;
            }
        }

        private System.Boolean _IsUsedPackPlan;
        [Browsable(true), DisplayName("IsUsedPackPlan")]
        public System.Boolean IsUsedPackPlan
        {
            get
            {
                return _IsUsedPackPlan;
            }
            set
            {
                _IsUsedPackPlan = value;
            }
        }

        private System.Boolean _IsUsedProduction;
        [Browsable(true), DisplayName("IsUsedProduction")]
        public System.Boolean IsUsedProduction
        {
            get
            {
                return _IsUsedProduction;
            }
            set
            {
                _IsUsedProduction = value;
            }
        }

        private System.Boolean _IsUsedCommercial;
        [Browsable(true), DisplayName("IsUsedCommercial")]
        public System.Boolean IsUsedCommercial
        {
            get
            {
                return _IsUsedCommercial;
            }
            set
            {
                _IsUsedCommercial = value;
            }
        }

        private System.Boolean _WillUseColorBreakDown;
        [Browsable(true), DisplayName("WillUseColorBreakDown")]
        public System.Boolean WillUseColorBreakDown
        {
            get
            {
                return _WillUseColorBreakDown;
            }
            set
            {
                _WillUseColorBreakDown = value;
            }
        }

        private System.Int16 _WeekDay;
        [Browsable(true), DisplayName("WeekDay")]
        public System.Int16 WeekDay
        {
            get
            {
                return _WeekDay;
            }
            set
            {
                _WeekDay = value;
            }
        }

        private System.Int16 _WeekEndDay;
        [Browsable(true), DisplayName("WeekEndDay")]
        public System.Int16 WeekEndDay
        {
            get
            {
                return _WeekEndDay;
            }
            set
            {
                _WeekEndDay = value;
            }
        }

        private System.Boolean _WillAllowMultiProductInOrder;
        [Browsable(true), DisplayName("WillAllowMultiProductInOrder")]
        public System.Boolean WillAllowMultiProductInOrder
        {
            get
            {
                return _WillAllowMultiProductInOrder;
            }
            set
            {
                _WillAllowMultiProductInOrder = value;
            }
        }

        private System.String _LocalFontName;
        [Browsable(true), DisplayName("LocalFontName")]
        public System.String LocalFontName
        {
            get
            {
                return _LocalFontName;
            }
            set
            {
                _LocalFontName = value;
            }
        }

        private System.Boolean _WillEnterProductSegmentFromProductDef;
        [Browsable(true), DisplayName("WillEnterProductSegmentFromProductDef")]
        public System.Boolean WillEnterProductSegmentFromProductDef
        {
            get
            {
                return _WillEnterProductSegmentFromProductDef;
            }
            set
            {
                _WillEnterProductSegmentFromProductDef = value;
            }
        }

        private System.Boolean _WillEnterItemSegmentFromItemDef;
        [Browsable(true), DisplayName("WillEnterItemSegmentFromItemDef")]
        public System.Boolean WillEnterItemSegmentFromItemDef
        {
            get
            {
                return _WillEnterItemSegmentFromItemDef;
            }
            set
            {
                _WillEnterItemSegmentFromItemDef = value;
            }
        }

        private System.Int16 _MaxAllowedWorkingHrPerDay;
        [Browsable(true), DisplayName("MaxAllowedWorkingHrPerDay")]
        public System.Int16 MaxAllowedWorkingHrPerDay
        {
            get
            {
                return _MaxAllowedWorkingHrPerDay;
            }
            set
            {
                _MaxAllowedWorkingHrPerDay = value;
            }
        }

        private System.Boolean _IsUsedHRMS;
        [Browsable(true), DisplayName("IsUsedHRMS")]
        public System.Boolean IsUsedHRMS
        {
            get
            {
                return _IsUsedHRMS;
            }
            set
            {
                _IsUsedHRMS = value;
            }
        }

        private System.Boolean _UseProductDefination;
        [Browsable(true), DisplayName("UseProductDefination")]
        public System.Boolean UseProductDefination
        {
            get
            {
                return _UseProductDefination;
            }
            set
            {
                _UseProductDefination = value;
            }
        }

        private System.Boolean _CanEditTemplatInPO;
        [Browsable(true), DisplayName("CanEditTemplatInPO")]
        public System.Boolean CanEditTemplatInPO
        {
            get
            {
                return _CanEditTemplatInPO;
            }
            set
            {
                _CanEditTemplatInPO = value;
            }
        }

        private System.Boolean _IsUsedSizeWiseDia;
        [Browsable(true), DisplayName("IsUsedSizeWiseDia")]
        public System.Boolean IsUsedSizeWiseDia
        {
            get
            {
                return _IsUsedSizeWiseDia;
            }
            set
            {
                _IsUsedSizeWiseDia = value;
            }
        }

        private System.Boolean _AllowSegmentCreationInCTM;
        [Browsable(true), DisplayName("AllowSegmentCreationInCTM")]
        public System.Boolean AllowSegmentCreationInCTM
        {
            get
            {
                return _AllowSegmentCreationInCTM;
            }
            set
            {
                _AllowSegmentCreationInCTM = value;
            }
        }

        private System.Boolean _IsUsedSizeWiseConsumtion;
        [Browsable(true), DisplayName("IsUsedSizeWiseConsumtion")]
        public System.Boolean IsUsedSizeWiseConsumtion
        {
            get
            {
                return _IsUsedSizeWiseConsumtion;
            }
            set
            {
                _IsUsedSizeWiseConsumtion = value;
            }
        }

        private System.String _CompanyNature;
        [Browsable(true), DisplayName("CompanyNature")]
        public System.String CompanyNature
        {
            get
            {
                return _CompanyNature;
            }
            set
            {
                _CompanyNature = value;
            }
        }

        private System.Boolean _UsePOAudit;
        [Browsable(true), DisplayName("UsePOAudit")]
        public System.Boolean UsePOAudit
        {
            get
            {
                return _UsePOAudit;
            }
            set
            {
                _UsePOAudit = value;
            }
        }

        private System.Boolean _DyeSubProcDep;
        [Browsable(true), DisplayName("DyeSubProcDep")]
        public System.Boolean DyeSubProcDep
        {
            get
            {
                return _DyeSubProcDep;
            }
            set
            {
                _DyeSubProcDep = value;
            }
        }

        private System.Boolean _UseKnitDyePlanner;
        [Browsable(true), DisplayName("UseKnitDyePlanner")]
        public System.Boolean UseKnitDyePlanner
        {
            get
            {
                return _UseKnitDyePlanner;
            }
            set
            {
                _UseKnitDyePlanner = value;
            }
        }

        private System.Boolean _IsUseMerchandisingMaping;
        [Browsable(true), DisplayName("IsUseMerchandisingMaping")]
        public System.Boolean IsUseMerchandisingMaping
        {
            get
            {
                return _IsUseMerchandisingMaping;
            }
            set
            {
                _IsUseMerchandisingMaping = value;
            }
        }

        private System.Boolean _WillUseSinglePOSingleStyle;
        [Browsable(true), DisplayName("WillUseSinglePOSingleStyle")]
        public System.Boolean WillUseSinglePOSingleStyle
        {
            get
            {
                return _WillUseSinglePOSingleStyle;
            }
            set
            {
                _WillUseSinglePOSingleStyle = value;
            }
        }

        private System.Boolean _CostingInPdnProcessSet;
        [Browsable(true), DisplayName("CostingInPdnProcessSet")]
        public System.Boolean CostingInPdnProcessSet
        {
            get
            {
                return _CostingInPdnProcessSet;
            }
            set
            {
                _CostingInPdnProcessSet = value;
            }
        }

        private System.Boolean _WillEnterLengthInFinQc;
        [Browsable(true), DisplayName("WillEnterLengthInFinQc")]
        public System.Boolean WillEnterLengthInFinQc
        {
            get
            {
                return _WillEnterLengthInFinQc;
            }
            set
            {
                _WillEnterLengthInFinQc = value;
            }
        }

        private System.Boolean _ShowBuyersPOInPOSearchScreen;
        [Browsable(true), DisplayName("ShowBuyersPOInPOSearchScreen")]
        public System.Boolean ShowBuyersPOInPOSearchScreen
        {
            get
            {
                return _ShowBuyersPOInPOSearchScreen;
            }
            set
            {
                _ShowBuyersPOInPOSearchScreen = value;
            }
        }

        private System.String _GoodsReceiptBy;
        [Browsable(true), DisplayName("GoodsReceiptBy")]
        public System.String GoodsReceiptBy
        {
            get
            {
                return _GoodsReceiptBy;
            }
            set
            {
                _GoodsReceiptBy = value;
            }
        }

        private System.Boolean _MentionAllColorSizeInMapping;
        [Browsable(true), DisplayName("MentionAllColorSizeInMapping")]
        public System.Boolean MentionAllColorSizeInMapping
        {
            get
            {
                return _MentionAllColorSizeInMapping;
            }
            set
            {
                _MentionAllColorSizeInMapping = value;
            }
        }

        private System.Boolean _UseWebTNA;
        [Browsable(true), DisplayName("UseWebTNA")]
        public System.Boolean UseWebTNA
        {
            get
            {
                return _UseWebTNA;
            }
            set
            {
                _UseWebTNA = value;
            }
        }

        private System.Boolean _MaxShipDateInPdnRef;
        [Browsable(true), DisplayName("MaxShipDateInPdnRef")]
        public System.Boolean MaxShipDateInPdnRef
        {
            get
            {
                return _MaxShipDateInPdnRef;
            }
            set
            {
                _MaxShipDateInPdnRef = value;
            }
        }

        private System.Boolean _AllowStaggeredDeliveryDateFromPdnRef;
        [Browsable(true), DisplayName("AllowStaggeredDeliveryDateFromPdnRef")]
        public System.Boolean AllowStaggeredDeliveryDateFromPdnRef
        {
            get
            {
                return _AllowStaggeredDeliveryDateFromPdnRef;
            }
            set
            {
                _AllowStaggeredDeliveryDateFromPdnRef = value;
            }
        }

        private System.Boolean _isSizeFilterable;
        [Browsable(true), DisplayName("isSizeFilterable")]
        public System.Boolean isSizeFilterable
        {
            get
            {
                return _isSizeFilterable;
            }
            set
            {
                _isSizeFilterable = value;
            }
        }

        private System.Boolean _UsedSegmentSensitivityInTemplate;
        [Browsable(true), DisplayName("UsedSegmentSensitivityInTemplate")]
        public System.Boolean UsedSegmentSensitivityInTemplate
        {
            get
            {
                return _UsedSegmentSensitivityInTemplate;
            }
            set
            {
                _UsedSegmentSensitivityInTemplate = value;
            }
        }

        #endregion


        protected void SetData(IDataRecord reader)
        {
            _RowID = reader.GetInt32("RowID");
            _IsUsedInventory = reader.GetBoolean("IsUsedInventory");
            _IsUsedOTS = reader.GetBoolean("IsUsedOTS");
            _IsUsedFabricControl = reader.GetBoolean("IsUsedFabricControl");
            _IsUsedWashing = reader.GetBoolean("IsUsedWashing");
            _IsUsedFixedAssets = reader.GetBoolean("IsUsedFixedAssets");
            _IsUsedPackPlan = reader.GetBoolean("IsUsedPackPlan");
            _IsUsedProduction = reader.GetBoolean("IsUsedProduction");
            _IsUsedCommercial = reader.GetBoolean("IsUsedCommercial");
            _WillUseColorBreakDown = reader.GetBoolean("WillUseColorBreakDown");
            _WeekDay = reader.GetInt16("WeekDay");
            _WeekEndDay = reader.GetInt16("WeekEndDay");
            _WillAllowMultiProductInOrder = reader.GetBoolean("WillAllowMultiProductInOrder");
            _LocalFontName = reader.GetString("LocalFontName");
            _WillEnterProductSegmentFromProductDef = reader.GetBoolean("WillEnterProductSegmentFromProductDef");
            _WillEnterItemSegmentFromItemDef = reader.GetBoolean("WillEnterItemSegmentFromItemDef");
            _MaxAllowedWorkingHrPerDay = reader.GetInt16("MaxAllowedWorkingHrPerDay");
            _IsUsedHRMS = reader.GetBoolean("IsUsedHRMS");
            _UseProductDefination = reader.GetBoolean("UseProductDefination");
            _CanEditTemplatInPO = reader.GetBoolean("CanEditTemplatInPO");
            _IsUsedSizeWiseDia = reader.GetBoolean("IsUsedSizeWiseDia");
            _AllowSegmentCreationInCTM = reader.GetBoolean("AllowSegmentCreationInCTM");
            _IsUsedSizeWiseConsumtion = reader.GetBoolean("IsUsedSizeWiseConsumtion");
            _CompanyNature = reader.GetString("CompanyNature");
            _UsePOAudit = reader.GetBoolean("UsePOAudit");
            _DyeSubProcDep = reader.GetBoolean("DyeSubProcDep");
            _UseKnitDyePlanner = reader.GetBoolean("UseKnitDyePlanner");
            _IsUseMerchandisingMaping = reader.GetBoolean("IsUseMerchandisingMaping");
            _WillUseSinglePOSingleStyle = reader.GetBoolean("WillUseSinglePOSingleStyle");
            _CostingInPdnProcessSet = reader.GetBoolean("CostingInPdnProcessSet");
            _WillEnterLengthInFinQc = reader.GetBoolean("WillEnterLengthInFinQc");
            _ShowBuyersPOInPOSearchScreen = reader.GetBoolean("ShowBuyersPOInPOSearchScreen");
            _GoodsReceiptBy = reader.GetString("GoodsReceiptBy");
            _MentionAllColorSizeInMapping = reader.GetBoolean("MentionAllColorSizeInMapping");
            _UseWebTNA = reader.GetBoolean("UseWebTNA");
            _MaxShipDateInPdnRef = reader.GetBoolean("MaxShipDateInPdnRef");
            _AllowStaggeredDeliveryDateFromPdnRef = reader.GetBoolean("AllowStaggeredDeliveryDateFromPdnRef");
            _isSizeFilterable = reader.GetBoolean("isSizeFilterable");
            _UsedSegmentSensitivityInTemplate = reader.GetBoolean("UsedSegmentSensitivityInTemplate");
        }
        public void GetCompanySettings()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.SysMan);
            IDataReader reader = null;
            String sql = "Select Top 1 * From CompanySettings";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    SetData(reader);
                    break;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                    reader.Close();
            }
        }
    }
}