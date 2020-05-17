<template>
    <div>
        <q-card>
          <q-card-section>
            <div class="text-h6">Administrator Form</div>
          </q-card-section>

          <q-card-section>
            <div class="row">
              <q-input v-model="newAdmin.firstName" label="First Name"></q-input>
              <q-input v-model="newAdmin.lastName" label="Last Name"></q-input>
              <q-input v-model="newAdmin.otherNames" label="Middle Name"></q-input>
              <q-input v-model="newAdmin.password" label = "Password"></q-input>
              <q-input v-model="newAdmin.userName" label="UserName"></q-input>
              <q-input v-model="newAdmin.email" label="Email Address"></q-input>
            </div>
          </q-card-section>
          
          <q-card-actions align="right">
            <q-btn flat label="Create" color="primary" v-close-popup @click="createAdmin" ></q-btn>
            <q-btn flat label="Cancel" color="primary" v-close-popup @click="cancelAdminCreation" ></q-btn>
          </q-card-actions>
        </q-card>
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