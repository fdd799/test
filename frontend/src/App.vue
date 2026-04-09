<script setup lang="ts">
import { RouterView } from 'vue-router'
import { useRouter } from 'vue-router'

const router = useRouter()

const navigateTo = (path:string) => {
    router.push(path)
}

</script>

<template>
    <nav>
        <button @click="navigateTo('/')">Home</button>
        <button @click="navigateTo('/table')">table</button>
    </nav>
    <RouterView />
</template>

<style scoped>
    button {
        margin: 0 10px 10px 0;
        background-color: rgb(60, 60, 207);
        color: #fff;
        padding: 10px 20px;
        border-radius: 5px;
        border: none;
        cursor: pointer;
    }
</style>
