<template>
  
  <div>
  
 <div class="row">
   <div class="col-12">
      <page1-app v-show="IsPage1"></page1-app>
      <page2-app v-show="IsPage2"></page2-app>
   </div>
 </div>
 <div class="q-pa-md">
  <q-toolbar class="bg-primary text-white q-my-md shadow-2">
      <q-btn stretch flat label="Back" @click="BackAction"/>
      <q-separator dark vertical />
      <q-btn stretch flat label="Next" @click="NextAction"/>
    </q-toolbar>
    </div>
</div>
</template>

<script>

import page1 from 'components/dataImport/page1.vue';
import page2 from 'components/dataImport/page2.vue';
import page3 from 'components/dataImport/page2.vue';
export default {
  computed: {
    showcreateinputdeckdialog() {
      return this.$store.getters['InputDeckStore/showcreateinputdeckdialog'];
    },
    showupdateinputdeckdialog(){
      return this.$store.getters['InputDeckStore/showupdateinputdeckdialog'];
    },
  },
  components: {
    'page1-app' : page1,
    'page2-app' : page2,
    'page3-app' : page3
  },
  data() {
    return {
      IsPage1: true,
      IsPage2: false,
      IsPage3: false
    };
  },
 methods: {
   NextAction(){
     var context = this;
     if(context.IsPage1 == true){
       context.IsPage1 = false;
       context.IsPage2 = true;
        context.IsPage2 = false;
     }
     if(context.IsPage2 == true){
       context.IsPage1 = false;
       context.IsPage2 = false;
       context.IsPage3 = true;
     }
   },
   BackAction(){
     var context = this;
     if(context.IsPage2 == true){
       context.IsPage3 = false;
       context.IsPage2 = false;
       context.IsPage1 = true;
     }
     if(context.IsPage3 == true){
       context.IsPage3 = false;
       context.IsPage2 = true;
       context.IsPage1 = false;
     }
   },
    setshowCreateFacultyDialog(){
      this.$store.commit('InputDeckStore/setshowCreateFacultyDialog')
    },
    showselectedInputdeck(selecteditem){
       this.$store.commit('InputDeckStore/showselectedInputdeck',selecteditem)
    }

  },
  created() {
    var context =this;
    this.$store.dispatch('InputDeckStore/getInputDeckDateStamp')
    this.$store.dispatch('InputDeckStore/getinputdeckmodels', editedinputdeck.id)

  }
  
}
</script>

<style>

</style>
