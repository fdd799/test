<script setup lang="ts">
    import { ref, onMounted } from 'vue'
    import axios from 'axios'
    const apiUrl = import.meta.env.VITE_API_URL

    interface HelloResponseDto {
        message: string
    }
    const helloResponse = ref<HelloResponseDto>({
        message: ''
    })

    onMounted(async () => {
        const res = await axios.get(`${apiUrl}/hello`)
        helloResponse.value = res.data
    })

</script>

<template>
    <h1>{{ helloResponse.message }}</h1>
</template>

<style scoped>
    
</style>