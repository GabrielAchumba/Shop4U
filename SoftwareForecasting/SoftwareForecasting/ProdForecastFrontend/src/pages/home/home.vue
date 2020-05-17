<template>
  <div class="block">
    <q-carousel
      animated
      v-model="slide"
      arrows
      navigation
      infinite
    >
      <q-carousel-slide name="first" img-src="statics/images/1.png"/>
      <q-carousel-slide name="second" img-src="statics/images/bg.jpg"/>
      <q-carousel-slide name="third" img-src="statics/images/slide1.png"/>
    </q-carousel>
  </div>
</template>

<script>
export default {
  data () {
    return {
      slide: 'first'
    }
  }
}
</script>

<style scoped>
   
</style>