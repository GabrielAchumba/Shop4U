<template>
    <div>
        <div class="q-pa-sm q-gutter-sm">
    <q-table title="Treats" :data="inputdeckmodelsformatted" :columns="columns" row-key="name" binary-state-sort>
      <template v-slot:body="props">
          <q-tr :props="props">
             <q-td key="version_Name" :props="props">{{ props.row.version_Name }}</q-td>
             <q-td key="asset_Team" :props="props">{{ props.row.asset_Team }}</q-td>
             <q-td key="field" :props="props">{{ props.row.field }}</q-td>
             <q-td key="reservoir" :props="props">{{ props.row.reservoir }}</q-td>
             <q-td key="drainage_Point" :props="props">{{ props.row.drainage_Point }}</q-td>
             <q-td key="production_String" :props="props">{{ props.row.production_String }}</q-td>
             <q-td key="module" :props="props">{{ props.row.module }}</q-td>
             <q-td key="pEEP_Project" :props="props">{{ props.row.pEEP_Project }}</q-td>
             <q-td key="activity_Entity" :props="props">{{ props.row.activity_Entity }}</q-td>
             <q-td key="flow_station" :props="props">{{ props.row.flow_station }}</q-td>
             <q-td key="hydrocarbon_Stream" :props="props">{{ props.row.hydrocarbon_Stream }}</q-td>
             <q-td key="resource_Class" :props="props">{{ props.row.resource_Class }}</q-td>
             <q-td key="change_Category" :props="props">{{ props.row.change_Category }}</q-td>
             <q-td key="technique_1P" :props="props">{{ props.row.technique_1P }}</q-td>
             <q-td key="uRo_1P_1C" :props="props">{{ props.row.uRo_1P_1C }}</q-td>
             <q-td key="uRo_Low" :props="props">{{ props.row.uRo_Low }}</q-td>
             <q-td key="uRo_2P_2C" :props="props">{{ props.row.uRo_2P_2C }}</q-td>
             <q-td key="uRo_3P_3C" :props="props">{{ props.row.uRo_3P_3C }}</q-td>
             <q-td key="np" :props="props">{{ props.row.np }}</q-td>
             <q-td key="uRg_1P_1C" :props="props">{{ props.row.uRg_1P_1C }}</q-td>
             <q-td key="uRg_Low" :props="props">{{ props.row.uRg_Low }}</q-td>
             <q-td key="uRg_2P_2C" :props="props">{{ props.row.uRg_2P_2C }}</q-td>
             <q-td key="uRg_3P_3C" :props="props">{{ props.row.uRg_3P_3C }}</q-td>
             <q-td key="gp" :props="props">{{ props.row.gp }}</q-td>
             <q-td key="init_Oil_Gas_Rate_1P_1C" :props="props">{{ props.row.init_Oil_Gas_Rate_1P_1C }}</q-td>
             <q-td key="init_Oil_Gas_Rate_Low" :props="props">{{ props.row.init_Oil_Gas_Rate_Low }}</q-td>
             <q-td key="init_Oil_Gas_Rate_2P_2C" :props="props">{{ props.row.init_Oil_Gas_Rate_2P_2C }}</q-td>
            <q-td key="init_Oil_Gas_Rate_3P_3C" :props="props">{{ props.row.init_Oil_Gas_Rate_3P_3C }}</q-td>
              <q-td key="aband_Oil_Gas_Rate_1P_1C" :props="props">{{ props.row.aband_Oil_Gas_Rate_1P_1C }}</q-td>
              <q-td key="aband_Oil_Gas_Rate_2P_2C" :props="props">{{ props.row.aband_Oil_Gas_Rate_2P_2C }}</q-td>
              <q-td key="aband_Oil_Gas_Rate_3P_3C" :props="props">{{ props.row.aband_Oil_Gas_Rate_3P_3C }}</q-td>
              <q-td key="init_BSW_WGR" :props="props">{{ props.row.init_BSW_WGR }}</q-td>
              <q-td key="aband_BSW_WGR_1P_1C" :props="props">{{ props.row.aband_BSW_WGR_1P_1C }}</q-td>
              <q-td key="aband_BSW_WGR_2P_2C" :props="props">{{ props.row.aband_BSW_WGR_2P_2C }}</q-td>
              <q-td key="aband_BSW_WGR_3P_3C" :props="props">{{ props.row.aband_BSW_WGR_3P_3C }}</q-td>
              <q-td key="init_GOR_CGR" :props="props">{{ props.row.init_GOR_CGR }}</q-td>
              <q-td key="aband_GOR_CGR_1P_1C" :props="props">{{ props.row.aband_GOR_CGR_1P_1C }}</q-td>
              <q-td key="aband_GOR_CGR_2P_2C" :props="props">{{ props.row.aband_GOR_CGR_2P_2C }}</q-td>
              <q-td key="aband_GOR_CGR_3P_3C" :props="props">{{ props.row.aband_GOR_CGR_3P_3C }}</q-td>
              <q-td key="lift_Gas_Rate" :props="props">{{ props.row.lift_Gas_Rate }}</q-td>
              <q-td key="plateau_Oil_Gas" :props="props">{{ props.row.plateau_Oil_Gas }}</q-td>
              <q-td key="in_year_Booking" :props="props">{{ props.row.in_year_Booking }}</q-td>
              <q-td key="LE_LV" :props="props">{{ props.row.LE_LV }}</q-td>
              <q-td key="pRCS" :props="props">{{ props.row.pRCS }}</q-td>
              <q-td key="on_stream_Date_1P_1C" :props="props">{{ props.row.on_stream_Date_1P_1C }}</q-td>
              <q-td key="on_stream_Date_2P_2C" :props="props">{{ props.row.on_stream_Date_2P_2C }}</q-td>
              <q-td key="on_stream_Date_3P_3C" :props="props">{{ props.row.on_stream_Date_3P_3C }}</q-td>
              <q-td key="remarks" :props="props">{{ props.row.remarks }}</q-td>
              <q-td key="tRANCHE" :props="props">{{ props.row.tRANCHE }}</q-td>
              <q-td key="actions" :props="props">
              <q-btn color="blue" label="Update" @click="showselectedInputdeck(props.row)" size=sm no-caps></q-btn>
              <q-btn color="red" label="Delete"  @click="deleteInputDeck(props.row)" size=sm no-caps></q-btn>
            </q-td>
          </q-tr>
        </template>
    </q-table>
  </div>

    </div>
</template>

<script>
export default {
  computed: {
    inputdeckmodelsformatted() {
      return this.$store.getters['InputDeckStore/inputdeckmodelsformatted'];
    },
    editedinputdeck(){
         return this.$store.getters['InputDeckStore/editedinputdeck'];
    },
    showcreateinputdeckdialog() {
      return this.$store.getters['InputDeckStore/showcreateinputdeckdialog'];
    },
    showupdateinputdeckdialog(){
      return this.$store.getters['InputDeckStore/showupdateinputdeckdialog'];
    },
    newinputdeck() {
        return this.$store.getters['InputDeckStore/newinputdeck'];
        },
        selectedinputdeckname() {
        return this.$store.getters['InputDeckStore/selectedinputdeckname'];
        }
  },
  data() {
    return {
      IsPage1: true,
      IsPage2: true,
        filemodel: null,
         selected_file:'',
        date: '2019/02/01',
        InputDeckName: '',
      dense: false,
      denseOpts: false,
      ActiveinputdeckName: "",
      
      columns: [
        { name: "version_Name", label: "Version Name", field: "", align: "left" },
        { name: "asset_Team", label: "Asset Team", field: "", align: "left" },
        { name: "field", label: "Field", field: "", align: "left" },
        { name: "reservoir", label: "Reservoir", field: "", align: "left" },
        { name: "drainage_Point", label: "Drainage Point", field: "", align: "left" },
        { name: "production_String", label: "Production_String", field: "", align: "left" },
        { name: "module", label: "Module", field: "", align: "left" },
        { name: "pEEP_Project", label: "PEEP Project", field: "", align: "left" },
        { name: "activity_Entity", label: "Activity Entity", field: "", align: "left" },
        { name: "flow_station", label: "Flow station", field: "", align: "left" },
        { name: "hydrocarbon_Stream", label: "Hydrocarbon Stream", field: "", align: "left" },
        { name: "resource_Class", label: "Resource Class", field: "", align: "left" },
        { name: "change_Category", label: "Change Category", field: "", align: "left" },
        { name: "technique_1P", label: "1P Technique", field: "", align: "left" },
        { name: "uRo_1P_1C", label: "URo 1P/1C", field: "", align: "left" },
        { name: "uRo_Low", label: "URo Low", field: "", align: "left" },
        { name: "uRo_2P_2C", label: "URo 2P/2C", field: "", align: "left" },
        { name: "uRo_3P_3C", label: "URo 3P/3C", field: "", align: "left" },
        { name: "np", label: "Np", field: "", align: "left" },
        { name: "uRg_1P_1C", label: "URg 1P/1C", field: "", align: "left" },
        { name: "uRg_Low", label: "URg Low", field: "", align: "left" },
        { name: "uRg_2P_2C", label: "URg 2P/2C", field: "", align: "left" },
        { name: "uRg_3P_3C", label: "URg 3P/3C", field: "", align: "left" },
        { name: "gp", label: "Gp", field: "", align: "left" },
        { name: "init_Oil_Gas_Rate_1P_1C", label: "Initial Oil/Gas Rate 1P/1C", field: "", align: "left" },
        { name: "init_Oil_Gas_Rate_Low", label: "Initial Oil/Gas Rate Low", field: "", align: "left" },
        { name: "init_Oil_Gas_Rate_2P_2C", label: "Initial Oil/Gas Rate 2P/2C", field: "", align: "left" },
        { name: "init_Oil_Gas_Rate_3P_3C", label: "Initial Oil/Gas Rate 3P/3C", field: "", align: "left" },
        { name: "aband_Oil_Gas_Rate_1P_1C", label: "Abandonment Oil/Gas Rate 1P/1C", field: "", align: "left" },
        { name: "aband_Oil_Gas_Rate_2P_2C", label: "Abandonment Oil/Gas Rate 2P/2C", field: "", align: "left" },
        { name: "aband_Oil_Gas_Rate_3P_3C", label: "Abandonment Oil/Gas Rate 3P/3C", field: "", align: "left" },
        { name: "init_BSW_WGR", label: "Initial BSW/WGR", field: "", align: "left" },
        { name: "aband_BSW_WGR_1P_1C", label: "Abandonment BSW/WGR 1P/1C", field: "", align: "left" },
        { name: "aband_BSW_WGR_2P_2C", label: "Abandonment BSW/WGR 2P/2C", field: "", align: "left" },
        { name: "aband_BSW_WGR_3P_3C", label: "Abandonment BSW/WGR 3P/3C", field: "", align: "left" },
        { name: "init_GOR_CGR", label: "Initial GOR/CGR", field: "", align: "left" },
        { name: "aband_GOR_CGR_1P_1C", label: "Abandonment GOR/CGR 1P/1C", field: "", align: "left" },
        { name: "aband_GOR_CGR_2P_2C", label: "Abandonment GOR/CGR 2P/2C", field: "", align: "left" },
        { name: "aband_GOR_CGR_3P_3C", label: "Abandonment GOR/CGR 3P/3C", field: "", align: "left" },
        { name: "lift_Gas_Rate", label: "lift Gas Rate", field: "", align: "left" },
        { name: "plateau_Oil_Gas", label: "Plateau Oil/Gas", field: "", align: "left" },
        { name: "in_year_Booking", label: "In-year Booking", field: "", align: "left" },
        { name: "lE/LV", label: "LE_LV", field: "", align: "left" },
        { name: "pRCS", label: "PRCS", field: "", align: "left" },
        { name: "on_stream_Date_1P_1C", label: "Onstream Date 1P/1C", field: "", align: "left" },
        { name: "on_stream_Date_2P_2C", label: "Onstream Date 2P/2C", field: "", align: "left" },
        { name: "on_stream_Date_3P_3C", label: "Onstream Date 3P/3C", field: "", align: "left" },
        { name: "remarks", label: "Remarks", field: "", align: "left" },
        { name: "tRANCHE", label: "TRANCHE", field: "", align: "left" },
        {
          name: "actions",
          label: "Actions",
          field: "actions",
          style: "width: 80px"
        }
      ]

    };
  },
 methods: {
   NextAction(){
     if(IsPage1 == true){
       IsPage1 = false;
       IsPage2 = true;
     }

   },
   BackAction(){
     if(IsPage2 == true){
       IsPage2 = false;
       IsPage1 = true;
     }

   },
   getUrl (files) {
      return `http://localhost:44344/api/InputDecks/upload`
    },
    deleteInputDeck(selecteditem){
      confirm("Are you sure you want to delete this department?") &&
        this.deleteDepartmentPrivate(selecteditem);
    },
    deleteInputDeckPrivate(selecteditem){
      this.$store.dispatch('InputDeckStore/deleteFaculty',selecteditem)
    },
    setshowCreateFacultyDialog(){
      this.$store.commit('InputDeckStore/setshowCreateFacultyDialog')
    },
    showselectedInputdeck(selecteditem){
       this.$store.commit('InputDeckStore/showselectedInputdeck',selecteditem)
    }

  },
  created() {
      console.log('created');

  }
  
}
</script>

<style>

</style>
