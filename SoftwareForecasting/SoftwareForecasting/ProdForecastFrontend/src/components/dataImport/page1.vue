<template>
  <div class="q-pa-md">

    <div class="row">
      <div class="col-12">
         <q-uploader
         label="Auto Uploader"
          auto-upload
          :url="getUrl"
          multiple
          />
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
            selected_file: null,
            check_if_document_upload:false,
             date: '2019/02/01',
             dense: false,
            denseOpts: false,
            ActiveSheetName: ""
        };
    },
    methods: {
        onValueChangeSetSheetValues(){

        },
        getUrl (files) {
          return `http://localhost:44344/api/InputDecks/upload`
        }
    }
}
</script>

<style scoped>

</style>