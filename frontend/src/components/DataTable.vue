<script setup lang="ts">
    interface Columns {
        key: string
        title: string
    }

    interface Datas {
        [key: string]: string | number
    }

    defineProps<{
        columns: Columns[]
        datas: Datas[]
    }>()
</script>

<template>
    <table class="w-1/2 border-collapse">
        <thead>
            <tr>
                <th v-for="column in columns" :key="column.key" class="border p-4">{{ column.title }}</th>
            </tr>
        </thead>
        <tbody>
            <tr v-for="data in datas" :key="data.pid">
                <td v-for="column in columns" :key="column.key" class="border p-4 text-center">{{ data[column.key] }}</td>
            </tr>
        </tbody>
    </table>
</template>