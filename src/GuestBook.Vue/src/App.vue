<template>
  <div id="app">
      <GuestBookHeading/>
      <GuestBookCommentsList/>
  </div>
</template>

<script>
import GuestBookCommentsList from '@/components/GuestBookCommentsList'

import GuestBookHeading from '@/components/GuestBookHeading'

export default {
  name: 'App',
        
  components: {
        GuestBookHeading,
        GuestBookCommentsList
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin: 0px;
  padding:0px;
}
</style>
