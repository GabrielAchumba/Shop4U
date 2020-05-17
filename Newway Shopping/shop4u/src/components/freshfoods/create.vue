<template>
    <div>
        <div class="row">
            <div class="col-12" style="Height: 10px"></div>   
        </div>

        <div class="row">
            <div class="col-1"></div>

            <div class="col-10">
                <q-card>
          
          <q-card-section>
            <div class="text-h6">Create Item Ticket</div>
          </q-card-section>

          <q-card-section>
            <!-- Name -->
                <div class="row">
                    <div class="col-12">
                        <q-input v-model="newAdmin.firstName" label="First Name"></q-input>
                    </div>   
                </div>

                <!-- Category -->
                <div class="row"> 
                    <div class="col-12">
                        <q-input v-model="newAdmin.firstName" label="First Name"></q-input>
                    </div>   
                </div>

                <!-- Status -->
                <div class="row">
                    <div class="col-12">
                        <q-input v-model="newAdmin.firstName" label="First Name"></q-input>
                    </div>   
                </div>

                <!-- Price -->
                <div class="row"> 
                    <div class="col-12">
                        <q-input v-model="newAdmin.firstName" label="First Name"></q-input>
                    </div>   
                </div>

                <!-- Units -->
                <div class="row">
                    <div class="col-12">
                        <q-input v-model="newAdmin.firstName" label="First Name"></q-input>
                    </div>   
                </div>
          </q-card-section>
          
          <q-card-actions align="right">
            <q-btn flat label="Create" color="primary" v-close-popup @click="createOrUpdateGood" ></q-btn>
          </q-card-actions>
        </q-card>
                
            </div>

            <div class="col-1" style="Height: 10px"></div>   
        </div>

        <div class="row">
            <div class="col-12" style="Height: 10px"></div>   
        </div>

        
        
    </div>
</template>

<script>
export default {
    computed: {
        newAdmin() {
        return this.$store.getters['administratorsStore/newAdmin'];
        }
      },
      methods: {
          createAdmin(){
          this.$store.dispatch('administratorsStore/createAdministrator')
      },
      cancelAdminCreation(){
        this.$store.commit('administratorsStore/cancelAdminCreation')
      }
    }
}
</script>

<style scoped>

</style>