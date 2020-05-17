<template>
  <q-page padding class="custompage">
    <app-homepage></app-homepage>
  </q-page>
</template>

<script>
import homepage from '../pages/home/home.vue';;
export default {
  components:{
    'app-homepage': homepage
  }
}
</script>

<style>
  .custompage{
    background-color: white;
  }
</style>
