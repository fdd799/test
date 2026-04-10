<script setup lang="ts">
    import { useRouter } from 'vue-router'

    const router = useRouter()

    const navigateTo = (path:string) => {
        router.push(path)
    }

    interface Props {
        path: string
        text: string
    }

    const props = defineProps<Props>()
</script>

<template>
    <button class="m-2 bg-blue-700 text-white px-4 py-2 rounded-md" @click="navigateTo(props.path)">{{ props.text }}</button>
</template>