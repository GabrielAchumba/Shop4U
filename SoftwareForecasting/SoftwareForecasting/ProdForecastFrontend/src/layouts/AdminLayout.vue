<template>
  <q-layout view="hHh lpR fFf">
    <q-header elevated>
      <q-toolbar>
        <q-btn
          flat
          dense
          round
          icon="menu"
          aria-label="Menu"
          @click="leftDrawerOpen = !leftDrawerOpen"
        />

        <q-toolbar-title class="absolute-center">
          Production Forecasting Tool
        </q-toolbar-title>

      </q-toolbar>
    </q-header>

    <q-drawer 
      v-model="leftDrawerOpen"
      :breakpoint="767"
      :width="200"
      bordered
      content-class="bg-primary"
    >
      <q-list dark>
        <q-item
        v-for="nav in navs"
        :key="nav.label"
        :to="nav.to"
        class="text-grey-4"
        exact
        clickable>
        <q-item-section avatar>
          <q-icon :name="nav.icon"/>
        </q-item-section>
        <q-item-section avatar>
          <q-item-label>{{ nav.label }}</q-item-label>
        </q-item-section>
        </q-item>

      </q-list>
    </q-drawer>

    <q-page-container>
      <router-view />
    </q-page-container>
  </q-layout>
</template>

<script>
export default {
  name: 'AdminLayout',
  data () {
    return {
      leftDrawerOpen: true,
       navs: [
              {
                label:'Import Data',
                icon: 'monetization_on',
                to:'/dataimport'
              },
              {
                label:'Input Deck',
                icon: 'verified_user',
                to:'/inputdeckList'
              },
              {
                label:'Run Forecast',
                icon: 'verified_user',
                to:'/optimization'
              }
  ]
    }
  },
  methods:{

  }
}
</script>

<style>
@media screen and (min-width: 768px) {
  .q-footer {
    display: none;
  }
}

.q-drawer .q-router-link--exact-active {
  color: white !important;  
}
</style>