<script setup lang="ts">
    import { useGetHello } from '@/composables/GetHello'
    const { helloResponse } = useGetHello()
</script>

<template>
    <h1 class="ml-2">{{ helloResponse.message }}</h1>
</template>