<template>
  <div class="q-pa-md">

    <div class="row">
      <div class="col-12">
          <q-select outlined v-model="ActiveSheetName"
                :options = "sheetNames"
                @input="onValueChangeSetSheetValues"
                :dense="dense" 
                :options-dense="denseOpts"
                label="Work Sheet">  
                <template v-slot:append>
                    <q-icon name="school" color="orange"/>
                </template>
            </q-select>
      </div>
    </div>

  <!--   <div class="row">
        <div class="col-12">
             <div class="q-gutter-md row items-start">
              <div>
                <div class="q-pb-sm">
                <q-badge color="teal">
                    Date Stamp
                </q-badge>
                </div>
                <div class="q-pa-md" style="max-width: 300px">
                    <q-input filled v-model="date" mask="date" :rules="['date']">
                    <template v-slot:append>
                        <q-icon name="event" class="cursor-pointer">
                        <q-popup-proxy ref="qDateProxy" transition-show="scale" transition-hide="scale">
                            <q-date v-model="date" @input="() => $refs.qDateProxy.hide()" />
                        </q-popup-proxy>
                        </q-icon>
                    </template>
                </q-input>
                </div>
            </div>
        </div>
    </div>
  </div> -->
  </div>
</template>

<script>
export default {
    data() {
        return {
             date: '2019/02/01',
             dense: false,
            denseOpts: false,
            ActiveSheetName: ""
        };
    },
    methods: {
        onValueChangeSetSheetValues(){

        },
        factoryFn (file) {
            //return `http://localhost:44344/api/InputDecks/upload`
      return new Promise((resolve, reject) => {
        resolve({
          url: `http://localhost:44344/api/InputDecks/upload`,
          method: 'POST'
        }).then(response => {
        //context.commit('setinputdeckmodelsformatted', response.data.inputDecks)         
        console.log( response.data) 

          resolve(response)
          
      })
      })
    },
    file_selected(file) {
      var context = this;
        context.selected_file = file[0];
        context.check_if_document_upload=true
        console.log(context.selected_file)
      },

uploadFile(){
        var context = this;
        let fd = new FormData();
        fd.append("file", context.selected_file);
        console.log(fd)
        this.$store.dispatch('InputDeckStore/getListOfWorkSheetNames',fd)

      }
    }
}
</script>

<style scoped>

</style>