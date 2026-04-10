<script setup lang="ts">
    import DataTable from '@/components/DataTable.vue'
    import { useGetTables } from '@/composables/getTable'
    const { datas } = useGetTables()

    interface Columns {
        key: string
        title: string
    }

    const columns: Columns[] = [ 
        { key: 'name', title: 'Name' }, 
        { key: 'type', title: 'Type' }, 
        { key: 'age', title: 'Age' } 
    ]
</script>

<template>
    <div class="grid place-items-center">
        <DataTable :columns="columns" :datas="datas" />
    </div>
</template>