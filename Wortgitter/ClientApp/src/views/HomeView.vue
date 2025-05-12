<template>
    <NavBar/>
    <Main class="main-view" />
</template>

<script>
import NavBar from '../components/NavBar.vue'
import Main from '../components/Main.vue'
export default {
    components: [NavBar, Main]
}

</script>

<style lang="css" scoped>
.main-view {
    margin: 5% auto;
    height: 80%;
    width: 80%;
}

</style>