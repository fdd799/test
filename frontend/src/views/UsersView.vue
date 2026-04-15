<script setup lang="ts">
    import { ref } from 'vue'
    import DataTable from '@/components/DataTable.vue'
    import CommonButton from '@/components/CommonButton.vue'
    import { useGetUsers } from '@/composables/GetUsers'
    import { useGetUserById } from '@/composables/GetUserById'

    interface Columns {
        key: string
        title: string
    }

    const columns: Columns[] = [
        { key: 'id', title: 'ID' },
        { key: 'name', title: 'Name' },
        { key: 'email', title: 'Email' }
    ]

    const userId = ref(1)
    const name = ref('')
    const email = ref('')

    const { users, getUsers } = useGetUsers()
    const { userById, getUserById } = useGetUserById()

    const activeView = ref<'allUsers' | 'userById' | null>(null)

    const handleGetUsers = async () => {
        await getUsers()
        activeView.value = 'allUsers'
    }

    const handleGetUserById = async () => {
        await getUserById(userId.value)
        activeView.value = 'userById'
    }
</script>

<template>
    <div>
        <div>
            <CommonButton :click="handleGetUsers" text="GetAllUsers" />
            <CommonButton :click="handleGetUserById" text="GetUserById" />
        </div>
        <div>
            <div class="m-2">
                <label for="userId">User ID：</label>
                <input class="border p-2 rounded-md" type="number" v-model="userId" />
            </div>
            <div class="m-2">
                <label for="name">Name：</label>
                <input class="border p-2 rounded-md" type="text" v-model="name" />
            </div>
            <div class="m-2">
                <label for="email">Email：</label>
                <input class="border p-2 rounded-md" type="email" v-model="email" />
            </div>
        </div>
    </div>
    
    <div v-if="activeView === 'allUsers'" class="grid place-items-center">
        <DataTable :columns="columns" :datas="users" />
    </div>
    <div v-if="activeView === 'userById'" class="grid place-items-center">
        <DataTable :columns="columns" :datas="[userById]" />
    </div>
</template>