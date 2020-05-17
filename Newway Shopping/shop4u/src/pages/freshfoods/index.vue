<template>
  
  <div id="q-app">
  <div class="q-pa-sm q-gutter-sm">
    <q-table title="Treats" :data="adminList" :columns="columns" row-key="name" binary-state-sort>
      <template v-slot:top>
          <q-btn dense color="secondary" label="Create Administrator" @click="showcreateadmin" no-caps></q-btn>
          
        <div class="q-pa-sm q-gutter-sm">

        <q-dialog v-model="showCreateAdministratorDialog">
          <create-app></create-app>
        </q-dialog>

    <q-dialog v-model="showUpdateAdministratorDialog">
        <edit-app></edit-app>
    </q-dialog>
          </div>
        
      </template>

      <template v-slot:body="props">
          <q-tr :props="props">
            <q-td key="firstName" :props="props">
              {{ props.row.firstName }}
              <q-popup-edit v-model="props.row.firstName" title="Update First Name" buttons>
                <q-input type="text" v-model="props.row.firstName" dense autofocus ></q-input>
              </q-popup-edit>
            </q-td>
            <q-td key="otherNames" :props="props">{{ props.row.otherNames }}</q-td>
            <q-td key="lastName" :props="props">{{ props.row.lastName }}</q-td>
            <q-td key="email" :props="props">{{ props.row.email }}</q-td>
           <q-td key="actions" :props="props">
              <q-btn color="blue" label="Update" @click="showselectedAdmin(props.row)" size=sm no-caps></q-btn>
              <q-btn color="red" label="Delete"  @click="deleteAdmin(props.row)" size=sm no-caps></q-btn>
            </q-td>
          </q-tr>
        </template>
    </q-table>
  </div>
</div>
</template>

<script>
import create from 'components/administrator/create.vue';
import edit from 'components/administrator/edit.vue';

export default {
  computed: {
    adminList() {
      return this.$store.getters['administratorsStore/administrators'];
    },
    showCreateAdministratorDialog() {
      return this.$store.getters['administratorsStore/showCreateAdministratorDialog'];
    },
    defaultItem() {
      return this.$store.getters['administratorsStore/defaultItem'];
    },
    showUpdateAdministratorDialog(){
      return this.$store.getters['administratorsStore/showUpdateAdministratorDialog'];
    }
  },
  components: {
    'create-app' : create,
    'edit-app' : edit
  },
  data() {
    return {
      columns: [
        { name: "firstName", label: "First Name", field: "", align: "left" },
        { name: "otherNames", label: "Middle Name", field: "", align: "left" },
        { name: "lastName", label: "Last Name", field: "", align: "left" },
        { name: "email", label: "Email Address", field: "", align: "left" },
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
    deleteAdmin(selectedAdmin){
      confirm("Are you sure you want to delete this administrator?") &&
        this.deletAdminPrivate(selectedAdmin);
    },
    deletAdminPrivate(selectedAdmin){
      this.$store.dispatch('administratorsStore/deleteAdministrator',selectedAdmin)
    },
    showcreateadmin(){
      this.$store.commit('administratorsStore/setshowCreateAdministratorDialog')
    },
    showselectedAdmin(selectedAdmin){
       this.$store.commit('administratorsStore/showselectedAdmin',selectedAdmin)
    }

  },
  created() {
    var context =this;
    this.$store.dispatch('administratorsStore/getAdministrators')

  }
  
}
</script>

<style>

</style>
