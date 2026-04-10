<script setup lang="ts">
    import { ref, onMounted } from 'vue'
    import axios from 'axios'
    const apiUrl = import.meta.env.VITE_API_URL

    interface TableResponseDto {
        pid: number
        name: string
        type: string
        age: number
    }

    const tables = ref<TableResponseDto[]>([])

    onMounted(async () => {
        const res = await axios.get(`${apiUrl}/table`)
        tables.value = res.data
    })

</script>

<template>
    <div class="table-container">
        <table>
            <thead>
                <tr>
                    <th>Name</th>
                    <th>Type</th>
                    <th>Age</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="table in tables" :key="table.pid">
                    <td>{{ table.name }}</td>
                    <td>{{ table.type }}</td>
                    <td>{{ table.age }}</td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<style scoped>
    .table-container {
        display: grid;
        place-items: center;
    }

    table {
        width: 50%;
        border-collapse: collapse;
    }

    th, td {
        border: 1px solid #000;
        padding: 10px;
        text-align: center;
    }
</style>