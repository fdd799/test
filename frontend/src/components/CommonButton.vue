<script setup lang="ts">
    interface Props {
        click?:() => void,
        text: string
    }

    const props = defineProps<Props>()
</script>

<template>
    <button class="m-2 bg-blue-400 text-white px-4 py-2 rounded-md cursor-pointer" @click="props.click?.()">
        {{ props.text }}        
    </button>
</template>